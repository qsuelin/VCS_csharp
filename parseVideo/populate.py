from DBcm import UseDatabase, SQLError
from parse import parse_video, get_hash, parse_filename
from pathlib import Path

config = {'host': '127.0.0.1',
          'user': 'vcs',
          'password': 'vcs',
          'database': 'VCS'}


def sync_db():
    check_db_valid()
    # iterate local files
    # get watch dirs
    with UseDatabase(config) as cursor:
        _SQL = """
        SELECT WatchDir FROM Watch
        """
        cursor.execute(_SQL)
        result = cursor.fetchall()  # list of tuple
        print(result)
        for record in result:
            dir_path = Path(record[0])
            sync_dir(dir_path)


def sync_dir(dir_path: Path):
    with UseDatabase(config) as cursor:
        for entry in dir_path.iterdir():
            if entry.is_file() and entry.suffix != '':
                # check size
                candidate_size = entry.stat().st_size
                _SQL = "SELECT * FROM VIDEOS WHERE Size = (%s)"
                cursor.execute(_SQL, (candidate_size,))
                result = cursor.fetchall()  # return a empty list if not found.
                # if no same size, insert directly
                if not result:
                    populate_file(entry)
                else:
                    # if same size, check hash
                    candidate_hash = get_hash(entry)
                    _SQL = "SELECT Hash, Dir, Title FROM VIDEOS"
                    cursor.execute(_SQL)
                    result = cursor.fetchall()
                    for record in result:
                        existing_hash, existing_dir, existing_title = record
                        # if hash equals, check if path equals, if yes, pass, if not insert
                        if candidate_hash == existing_hash and entry != (Path(existing_dir)/existing_title):
                            populate_file(entry)
            elif entry.is_dir():
                sync_dir(entry)


def check_db_valid():
    """
    db -> local. Make sure all the records in db still exits locally.
    :return: None
    """
    with UseDatabase(config) as cursor:
        _SQL = """SELECT Dir, Title FROM VIDEOS"""
        cursor.execute(_SQL)
        result = cursor.fetchall() # list of tuple
        existing_files_gc = ((item[0], item[1]) for item in result)
        # traverse the dir, delete record if not exist.
        for parent_path, title in existing_files_gc:
            if not (Path(parent_path)/title).exists():
                _SQL = """DELETE FROM VIDEOS WHERE Dir=(%s) AND Title=(%s)"""
                cursor.execute(_SQL, (parent_path, title))


def update_duptable(entry):
    candidate_hash = get_hash(entry)
    with UseDatabase(config) as cursor:
        _SQL = "SELECT Dir, Title FROM VIDEOS WHERE VideoId = (%s)"
        cursor.execute(_SQL, (candidate_hash,))
        result = cursor.fetchone()
        existing_dir, existing_title = result[0], result[1], result[2]
        _SQL = """
        INSERT INTO DUP 
        (VideoId, Dir, Title)
        VALUES
        (%s, %s, %s)"""
        cursor.execute(_SQL, (candidate_hash, existing_dir, existing_title,))
        cursor.execute(_SQL, (candidate_hash, str(entry.parent), parse_filename(entry.stem))[0])


def init_dir(dir_str: str):
    update_watch(dir_str)
    walk_dir(dir_str)


def walk_dir(dir_str: str):
    dir_path = Path(dir_str)

    for entry in dir_path.iterdir():
        if entry.is_file() and entry.suffix != '':
            print(entry)
            populate_file(entry)
        elif entry.is_dir():
            walk_dir(entry)


def update_watch(dir_str):
    """given a dir_str, update the watch table.
    if dir_str is child of any record, discard dir_str. stop iteration
    if dir_str is parent of any record, then update record and delete all children.
    if dir_str is not child of any record, either parent of any, then insert dir_str."""
    with UseDatabase(config) as cursor:
        _SQL = """
        SELECT WatchDir FROM Watch
        """
        cursor.execute(_SQL)
        watchlist = cursor.fetchall() # list of tuples
        existing_dirlist = [record[0] for record in watchlist]
        is_new = True
        is_child_of_any = False
        for record in existing_dirlist:
            if check_descendant(record, dir_str):
                is_new = False
                break
            elif check_descendant(dir_str, record) and not is_child_of_any:
                is_new = False
                is_child_of_any = True
                _SQL = """
                UPDATE WATCH SET WatchDir=(%s) WHERE WatchDir=(%s)"""
                cursor.execute(_SQL, (dir_str, record))
            elif check_descendant(dir_str, record) and is_child_of_any:
                _SQL = """DELETE FROM WATCH WHERE WatchDir=(%s)"""
                cursor.execute(_SQL, (record,))
            else:
                pass

        if is_new:
            _SQL = """INSERT INTO WATCH (WatchDir) VALUES (%s)"""
            cursor.execute(_SQL, (dir_str,))


def check_descendant(existing_str, candidate_str) -> bool:
    """check candidate_str is child of existing_str"""
    existing_path = Path(existing_str)
    candidate_path = Path(candidate_str)
    existing_path_tuple = existing_path.parents
    candidate_path_tuple = candidate_path.parents
    return all(item in existing_path_tuple for item in candidate_path_tuple)


def populate_file(path: Path):
    metadata = parse_video(path)
    if metadata is None:
        return
    print(metadata)
    with UseDatabase(config) as cursor:
        _SQL = "SELECT Id FROM VIDEOS"
        cursor.execute(_SQL)
        result = cursor.fetchall()
        if any(metadata['id'] == record[0] for record in result):
            update_duptable(path)
        else:
            _SQL = """
            INSERT INTO VIDEOS 
            (Hash, Title, Channel, Date, Container, Dir, Size, Duration, Width, Height, Video_Codec, Audio_Codec) 
            VALUES 
            (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)
            """

            cursor.execute(_SQL, (metadata['hash'],
                              metadata['title'],
                              metadata['channel'],
                              metadata['date'],
                              metadata['container'],
                              metadata['dir'],
                              metadata['size'],
                              metadata['duration'],
                              metadata['width'],
                              metadata['height'],
                              metadata['video_codec'],
                              metadata['audio_codec']
                              ))


if __name__ == '__main__':
    directory = "/Volumes/video/Youtube/机械动作_mechanism 常用机构仿真动画"
    sync_db()

from DBcm import UseDatabase, SQLError
from parse import parse_video
from pathlib import Path

config = {'host': '127.0.0.1',
          'user': 'vcs',
          'password': 'vcs',
          'database': 'VCS'}


def populate_dir(dir: str):
    for entry in Path(dir).iterdir():
        if entry.is_file() and entry.suffix != "":
            populate_file(entry)
        elif entry.is_dir():
            populate_dir(entry)


def populate_file(path: Path):
    metadata = parse_video(path)
    with UseDatabase(config) as cursor:
        _SQL = """
        insert into Videos 
        (Id, Title, Channel, Date, Container, Dir, Size, Duration, Width, Height, Video_Codec, Audio_Codec) 
        values 
        (%d, %s, %s, %s, %s, %s, %d, %d, %d, %d, %s, %s)
        """

        cursor.execute(_SQL, (metadata['id'],
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
    directory = "/Volumes/video/Youtube/机械动作_mechanism 常用机构仿真动画/trinityscsp 机械动画仿真"
    populate_dir(directory)

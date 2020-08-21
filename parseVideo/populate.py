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
               insert into Videos (title, Channel, Date, Container, Size, Duration, Resolution, Video_Codec, Audio_Codec)
               values
               (%s, %s, %s, %s, %s, %s, %s, %s, %s)"""
        if 'duration' in metadata:
            if metadata['date'] is None:
                cursor.execute(_SQL, (
                    metadata['title'],
                    metadata['channel'],
                    None,
                    metadata['container'],
                    metadata['size'],
                    metadata['duration'],
                    metadata['resolution'],
                    metadata['video_codec'],
                    metadata['audio_codec']))
            else:
                cursor.execute(_SQL, (
                    metadata['title'],
                    metadata['channel'],
                    str(metadata['date']),
                    metadata['container'],
                    metadata['size'],
                    metadata['duration'],
                    metadata['resolution'],
                    metadata['video_codec'],
                    metadata['audio_codec']))


if __name__ == '__main__':
    directory = "/Volumes/video/Youtube/机械动作_mechanism 常用机构仿真动画/trinityscsp 机械动画仿真"
    populate_dir(directory)

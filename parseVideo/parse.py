import hashlib

from moviepy.editor import VideoFileClip
import time
from pathlib import Path
import datetime
import ffmpeg

import subprocess
import shlex
import json
import pprint


def parse_video(path: Path) -> dict:
    metadata = {k: None for k in
                ['title', 'channel', 'date', 'container', 'dir', 'size', 'duration', 'width', 'height',
                 'video_codec', 'audio_codec']}

    metadata['id'] = get_hash(path)
    
    filename = path.stem
    title, channel, date = parse_filename(filename)
    metadata['title'] = title
    metadata['channel'] = None if channel == "NA" else channel
    metadata['date'] = None if date == "NA" else date

    metadata['container'] = path.suffix[1:]

    metadata['dir'] = path.parent

    filesize = path.stat().st_size
    metadata['size'] = filesize

    vid = ffmpeg.probe(path)
    vid_metalist = vid['streams']
    vid_metalist_video = vid_metalist[0]
    vid_metalist_audio = vid_metalist[1]
    duration_sec = vid_metalist_video.get('duration')
    duration_str = time.strftime('%H:%M:%S', time.gmtime(int(float(duration_sec))))
    metadata['duration'] = duration_str

    metadata['width'] = vid_metalist_video.get('codedwidth')
    metadata['height'] = vid_metalist_video.get('coded_height')
    metadata['video_codec'] = vid_metalist_video.get('codec_name')
    metadata['audio_codec'] = vid_metalist_audio.get('codec_name')
    # metadata['resolution'] = '{} X {}'.format(metadata['height'], metadata['width'])

    return metadata


def get_hash(path: Path):
    with open(str(path), 'rb') as f:
        file_hash = hashlib.blake2b()
        while chunk := f.read(8192):
            file_hash.update(chunk)
    return file_hash.hexdigest()


def findVideoMeta(filepath):
    cmd = "ffprobe -v quiet -print_format json -show_streams"
    args = shlex.split(cmd)
    args.append(filepath)
    ffprobeOutput = subprocess.check_output(args).decode('utf-8')
    ffprobeOutput = json.loads(ffprobeOutput)
    return ffprobeOutput


def convert_byte(filesize) -> str:
    KB = 1024
    MB = 1024 * 1024
    GB = 1024 * 1024 * 1024

    if filesize < KB:
        return str(filesize) + 'B'
    elif KB < filesize < MB:
        return str(round(filesize / KB, 1)) + "KB"
    elif MB < filesize < GB:
        return str(round(filesize / MB, 1)) + "MB"
    else:
        return str(round(filesize / GB, 1)) + "GB"


def parse_filename(filename) -> tuple:
    namelist = filename.split('-')

    if len(namelist) < 3:
        title = namelist[0]
        channel = None;
        date = None;
    else:
        title = ''.join(namelist[:-2])
        channel = namelist[-2]
        date_str = namelist[-1]
        date = datetime.date(int(date_str[:4]), int(date_str[4:6]), int(date_str[6:]))

    return title, channel, date


if __name__ == '__main__':
    filepath = "/Users/lin/Desktop/Coulisse mechanism 6-thang010146-20111109.mkv"

    ffprobeOutput = findVideoMeta(filepath)
    pp = pprint.PrettyPrinter(indent=2)
    pp.pprint(ffprobeOutput)
    #
    # video = VideoFileClip(filepath)
    # filename = Path(filepath).stem
    #
    # duration_sec = int(video.duration)
    # print(duration_sec)
    # duration_str = time.strftime('%H:%M:%S', time.gmtime(duration_sec))
    # print(duration_str)
    #
    # filesize = Path(filepath).stat().st_size
    # print(filesize)
    # print(convert_byte(filesize))
    #
    # vid = ffmpeg.probe(filepath)
    # duration_sec_ffmpeg = vid['streams'][0]['duration'];
    # print(int(duration_sec_ffmpeg))

    path = Path(filepath)
    print(parse_video(path))

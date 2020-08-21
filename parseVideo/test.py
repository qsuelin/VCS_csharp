#!/usr/local/bin/python3
import subprocess
import shlex
import json
import cv2


# function to find the resolution of the input video file
def findVideoMetada(pathToInputVideo):
    cmd = "ffprobe -v quiet -print_format json -show_streams"
    args = shlex.split(cmd)
    args.append(pathToInputVideo)
    # run the ffprobe process, decode stdout into utf-8 & convert to JSON
    ffprobeOutput = subprocess.check_output(args).decode('utf-8')
    ffprobeOutput = json.loads(ffprobeOutput)

    # prints all the metadata available:
    import pprint
    pp = pprint.PrettyPrinter(indent=2)
    pp.pprint(ffprobeOutput)

    # for example, find height and width
    height = ffprobeOutput['streams'][0]['height']
    width = ffprobeOutput['streams'][0]['width']

    print(height, width)
    return height, width


def hachoir(filepath):
    cmd = 'hachoir-metadata'
    process = subprocess.Popen([cmd, filepath], stdout=subprocess.PIPE, stderr=subprocess.STDOUT, universal_newlines=True)
    metadata = []
    for output in process.stdout:
        info = {}
        line = output.strip().split(":")
        info[line[0].strip()] = line[1].strip()
        metadata.append(info)

    return metadata

def opencv(filepath):
    video = cv2.VideoCapture(filepath)
    height = video.get(cv2.CAP_PROP_FRAME_HEIGHT)
    width = video.get(cv2.CAP_PROP_FRAME_WIDTH)
    framecount = video.get(cv2.CAP_PROP_FRAME_COUNT)
    frame_per_sec = video.get(cv2.CAP_PROP_FPS)
    return height, width, framecount, frame_per_sec


if __name__ == '__main__':
    filepath = "/Users/lin/Desktop/Cam and sine mechanism 2-thang010146-20130221.mp4"
    findVideoMetada(filepath)
    print(opencv(filepath))
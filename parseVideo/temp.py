import os
import pathlib


dir = "/Users/lin/Desktop"
# for filepath in pathlib.Path(dir).glob('**/*'):
#     print(filepath.absolute())
# print("#######")

file = '/Users/lin/Desktop/Desktop - LQ Shared MacBook Pro/.DS_Store'
temp = pathlib.Path(file)
print(temp.suffix == "")
print('x', temp)

def getpath(dir):
    for entry in pathlib.Path(dir).iterdir():
        if entry.is_file() and entry.suffix != "":
            print(entry)
        elif entry.is_dir():
            getpath(entry)
getpath(dir)
# directory = os.scandir(dir)
# print(directory)
#
# for entry in directory:
#     print(entry)
#
# for root, dir, f in os.walk(directory):
#     for file in f:
#         print(os.path.join(root,file))


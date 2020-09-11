# Overview
The goal of the video catalog system(VCS) application is to manage TB-size local videos regarding to robotics. It implements a comprehensive tag system so that users can browse and search related videos via complex metrics as well as edit tags for specific video. This application is meant to be an auxiliary tool for mechanism/electronics design of robots.

# Features
1. Customized authentication system for different users
1. Populate video database automatically with related metadata from videos
1. Display video in a list view
1. Users can edit tags for specific video
1. Users can search video via tag
1. Users can click and play the video on the fly

# Stack
1. Video ingest: Python, ffmpeg library
1. Server: ASP.NET Core
1. Front end: BootStrap, Razor Template
1. Database: MySQL


# Cracking Down Challenges
1. Implement a de-duplicate algorithm   
    * Duplicated files
    * Deleted files
    * Moved files
    * Renamed files
1. Detecting corrupt, truncated, damaged files
1. Robust parsing script for various format of video files
    * Not all formats store duration information at stream level, eg: Matroska
    * Some files don't have standard filenames
1. Manual duplication handling
    * show the complete list of alternative paths
    * ask user to pick the one to keep
    * call I/O to delete other files on local disk


# ER Diagram

# UML Activity/Sequence Diagram

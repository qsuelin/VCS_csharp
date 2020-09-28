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
1. Robust parsing script for various format of video files
    * Not all formats store duration information at stream level, eg: `Matroska`
    * Some files don't have standard filenames or multiple '.', eg:
    `Screw-Wedge Table Feed Mechanism-Mechanisms X-20161203.f136.mp4`
1. Manual duplication handling
    * show the complete list of alternative paths
    * ask user to pick the one to keep
    * call I/O to delete other files on local disk
1. Call Python script in C#
1. Optimize database performance
    * create index on columns: Size, Hash
1. Sync on-disk file -> DB
    * Create TABLE WatchDirs to track on disk directories to watch   
    * Walk through all the directories in WatchDirs on disk, and check if size/hash exists  in DB
    * Update WatchDirs when load new directories. Make sure WatchDir is not a parent/child of any existing record in WatchDirs
1. Detecting corrupt, truncated, damaged files


# Design
## Iteration 1: Table Dup   
Scenario: In table Videos, make hash as primary key, and make it as foreign key in table Dup.    
Problem: difficulty to track changes of on-disk VS TABLE Dup

## Iteration 2:  No Dup table. Hash not primary
Scenorio: Auto-incremented primary key for Videos, non-unique hash meaning there will be multiple same videos in TABLE Videos. Then there will be no need for TABLE Dup.

# ER Diagram

# UML Activity/Sequence Diagram

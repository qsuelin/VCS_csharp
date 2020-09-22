using System;
using System.Collections.Generic;
using VCS.Models;

namespace VCS.ViewModel
{
    public class DetailViewModel   
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string Container { get; set; }
        public string Video_Codec { get; set; }
        public string Audio_Codec { get; set; }


        public DetailViewModel(Video theVideo)
        {
            VideoId = theVideo.Id;
            Title = theVideo.Title;
            Duration = GetDurationFormat(theVideo.Duration);
            Size = ConvertByte(theVideo.Size);
            Resolution = GetResolution(theVideo.Width, theVideo.Height);
            Container = theVideo.Container;
            Video_Codec = theVideo.Video_Codec;
            Audio_Codec = theVideo.Audio_Codec;

        }


        private String GetDurationFormat(int seconds)
        {
            TimeSpan duration_str = TimeSpan.FromSeconds(seconds);
            return duration_str.ToString(@"hh\:mm\:ss");
        }


        private String ConvertByte(int bytes)
        {
            int KB = 1024;
            int MB = 1024 * 1024;
            int GB = 1024 * 1024 * 1024;

            if (bytes < KB)
            {
                return bytes.ToString() + "B";
            } else if (bytes < MB)
            {
                return Math.Round((double)bytes / KB, 1).ToString() + "KB";
            } else if (bytes < GB)
            {
                return Math.Round((double)bytes / MB, 1).ToString() + "MB";
            } else
            {
                return Math.Round((double)bytes / GB, 1).ToString() + "GB";
            }
        }

        private String GetResolution(int width, int height)
        {
            return $"{width} X {height}";
        }

        public DetailViewModel()
        {
        }
    }
}

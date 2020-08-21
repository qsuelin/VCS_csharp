using System;
using System.Collections.Generic;
using VCS.Models;

namespace VCS.ViewModel
{
    public class DetailViewModel   
    {
        public int VideoId { get; set; }
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
            Duration = theVideo.Duration;
            Size = theVideo.Size;
            Resolution = theVideo.Resolution;
            Container = theVideo.Container;
            Video_Codec = theVideo.Video_Codec;
            Audio_Codec = theVideo.Audio_Codec;

        }

        public DetailViewModel()
        {
        }
    }
}

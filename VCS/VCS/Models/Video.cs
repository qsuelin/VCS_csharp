using System;
using System.Collections.Generic;

namespace VCS.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Channel { get; set; }
        public DateTime Date { get; set; }

        public DateTime Duration { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string Container { get; set; }
        public string Video_Codec { get; set; }
        public string Audio_Codec { get; set; }
        public string Video_bitrate { get; set; }

        //public List<Tag> Tags { get; set; }


        public Video()
        {
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object obj)
        {
            return obj is Video @video &&
                Id == @video.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

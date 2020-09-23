using System;
using System.Collections.Generic;

namespace VCS.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Title { get; set; }
        public string Channel { get; set; }
        public DateTime Date { get; set; }
        public string Container { get; set; }
        public string Dir { get; set; }
        public int Size { get; set; }
        public int Duration { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Video_Codec { get; set; }
        public string Audio_Codec { get; set; }

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

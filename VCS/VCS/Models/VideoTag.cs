using System;
namespace VCS.Models
{
    public class VideoTag
    {
        public int VideoId { get; set; }
        public Video video { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public VideoTag()
        {
        }
    }
}

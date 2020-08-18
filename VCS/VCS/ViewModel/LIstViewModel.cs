using System;
using System.Collections.Generic;
using VCS.Models;

namespace VCS.ViewModel
{
    public class ListViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Channel { get; set;}
        public string Date { get; set; }
        public string TagText { get; set; }

        public ListViewModel (Video theVideo, List<VideoTag> videoTags)
        {
            VideoId = theVideo.Id;
            Title = theVideo.Title;
            Channel = theVideo.Channel;
            Date = theVideo.Date.ToShortDateString();

            TagText = "";
            for (int i = 0; i < videoTags.Count; i++)
            {
                TagText += videoTags[i].Tag.Name;
                if (i < videoTags.Count - 1)
                {
                    TagText += ", ";
                }
            }

        }
    }
}

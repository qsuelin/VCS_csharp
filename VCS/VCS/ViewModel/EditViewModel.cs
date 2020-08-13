using System;
using System.Collections.Generic;
using VCS.Models;

namespace VCS.ViewModel
{
    public class EditViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string TagText { get; set; }
        public List<VideoTag> VideoTags {get; set;}
        public string TagName { get; set; }

        public EditViewModel(Video theVideo, List<VideoTag> videoTags)
        {
            VideoId = theVideo.Id;
            Title = theVideo.Title;
            VideoTags = videoTags;

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

        public EditViewModel()
        {
        }

    }
        
    
}

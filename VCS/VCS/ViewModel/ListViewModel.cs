using System;
using System.Collections.Generic;
using VCS.Models;

namespace VCS.ViewModel
{
    public class ListViewModel
    {
     
        public List<Video> VideoList { get; set; }

        public ListViewModel(List<Video> videoList)
        {
            VideoList = videoList;
        }
    }
}

using System;
namespace VCS.ViewModel
{
    public class SearchViewModel
    {
        public string ToSearch { get; set; }

        public SearchViewModel(string toSearch)
        {
            ToSearch = toSearch;
        }
    }
}

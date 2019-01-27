using System;

namespace Linerath_Blog.Web.ViewModels
{
    public class BaseViewModel
    {
        public String Category { get; set; }
        public String SearchText { get; set; }
        public String ReturnUri { get; set; }

        public BaseViewModel(String category, String searchText)
        {
            Category = category;
            SearchText = searchText;
        }
    }
}
using System;

namespace Linerath_Blog.Web.ViewModels
{
    public class BaseViewModel
    {
        public String Category { get; set; }
        public String SearchText { get; set; }
        public bool? CaseSensetive { get; set; }
        public String ReturnUri { get; set; }

        public BaseViewModel(String category, String searchText, bool? caseSensetive)
        {
            Category = category;
            SearchText = searchText;
            CaseSensetive = caseSensetive;
        }
    }
}
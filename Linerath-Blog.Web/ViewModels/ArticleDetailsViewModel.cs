using System;
using Linerath_Blog.DAL.Entities;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticleDetailsViewModel : BaseViewModel
    {
        public Article Article { get; set; }
        public String ReturnUri { get; set; }

        public ArticleDetailsViewModel(String category, String searchText, bool? caseSensetive)
            :base(category, searchText, caseSensetive)
        { }
    }
}
using System;
using System.Collections.Generic;
using Linerath_Blog.Web.Enums;
using Linerath_Blog.Web.Models;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArchiveArticlesViewModel : BaseViewModel
    {
        public List<ArticleTitleGroup> ArticlesGroups { get; set; }
        public ArchiveFilter Filter { get; set; }

        public ArchiveArticlesViewModel(String category, String searchText)
            : base(category, searchText)
        {
            ArticlesGroups = new List<ArticleTitleGroup>();
        }
    }
}
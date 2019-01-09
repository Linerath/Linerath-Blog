using System;
using Linerath_Blog.Web.Models;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticlesSummariesViewModel : BaseViewModel
    {
        public List<Article> Articles { get; set; }
        public PaginationModel PaginationModel { get; set; }

        public ArticlesSummariesViewModel(String category, String searchText, bool? caseSensetive)
            : base(category, searchText, caseSensetive)
        {
            Articles = new List<Article>();
        }
    }
}
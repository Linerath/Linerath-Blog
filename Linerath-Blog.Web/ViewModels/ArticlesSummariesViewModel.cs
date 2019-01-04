using Linerath_Blog.DAL.Entities;
using Linerath_Blog.Web.Models;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticlesSummariesViewModel
    {
        public List<Article> Articles { get; set; }
        public PaginationModel PaginationModel { get; set; }

        public ArticlesSummariesViewModel()
        {
            Articles = new List<Article>();
        }
    }
}
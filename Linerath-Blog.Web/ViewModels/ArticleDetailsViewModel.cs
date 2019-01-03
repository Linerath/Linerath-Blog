using Linerath_Blog.DAL.Entities;
using System;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public Article Article { get; set; }
        public String ReturnUri { get; set; }
    }
}
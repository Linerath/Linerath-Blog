using System;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;

namespace Linerath_Blog.Web.Models
{
    public class ArticleTitleGroup
    {
        public List<ArticleTitle> Articles { get; set; }
        public String GroupName { get; set; }

        public ArticleTitleGroup()
        {
            Articles = new List<ArticleTitle>();
        }
    }
}
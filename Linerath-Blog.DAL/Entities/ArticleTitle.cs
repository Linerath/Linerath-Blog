using System;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Entities
{
    public class ArticleTitle
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Category> Categories { get; set; }

        public ArticleTitle()
        {
            Categories = new List<Category>();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public String Summary { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Category> Categories { get; set; }

        public Article()
        {
            Categories = new List<Category>();
        }
    }
}

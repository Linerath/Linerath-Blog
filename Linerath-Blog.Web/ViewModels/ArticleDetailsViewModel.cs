using Linerath_Blog.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Subject> Subjects { get; set; }
        public String ReturnUri { get; set; }

        public ArticleDetailsViewModel()
        {
            Subjects = new List<Subject>();
        }
    }
}
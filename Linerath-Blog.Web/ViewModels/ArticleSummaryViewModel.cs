using System;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;

namespace Linerath_Blog.Web.ViewModels
{
    public class ArticleSummaryViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Subject> Subjects { get; set; }

        public ArticleSummaryViewModel()
        {
            Subjects = new List<Subject>();
        }
    }
}
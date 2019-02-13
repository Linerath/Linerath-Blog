using System;

namespace Linerath_Blog.Web.ViewModels
{
    public class NewArticleViewModel
    {
        public String Title { get; set; }
        public String Body { get; set; }
        public String Summary { get; set; }
        public int[] Categories { get; set; }
    }
}
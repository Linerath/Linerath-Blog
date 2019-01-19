using System;

namespace Linerath_Blog.Web.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public String Body { get; set; }
        public String Sender { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
using System;

namespace Linerath_Blog.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public String Body { get; set; }
        public String Sender { get; set; }
    }
}

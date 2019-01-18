using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linerath_Blog.DAL.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private String connectionString;

        public List<Comment> GetComments(int articleId)
        {
            // fake
            return null;
        }
    }
}

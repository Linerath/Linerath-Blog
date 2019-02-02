using Linerath_Blog.DAL.Entities;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface ICommentsRepository
    {
        List<Comment> GetComments(int articleId);
        void AddComment(int articleId, Comment comment);
    }
}

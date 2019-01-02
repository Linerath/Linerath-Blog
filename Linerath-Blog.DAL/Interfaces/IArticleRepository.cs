using Linerath_Blog.DAL.Entities;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        Article GetArticleById(int id);
    }
}

using Linerath_Blog.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles(String category = null);
        List<Category> GetAllCategories();
        Article GetArticleById(int id);
    }
}

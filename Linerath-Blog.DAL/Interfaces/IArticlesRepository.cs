using Linerath_Blog.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface IArticlesRepository
    {
        List<Article> GetAllArticles(String category = null, String searchText = null, bool caseSensetive = false);
        List<Category> GetAllCategories();
        Article GetArticleById(int id);
    }
}

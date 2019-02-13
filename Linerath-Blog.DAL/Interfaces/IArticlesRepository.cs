using System;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface IArticlesRepository
    {
        int AddArticle(Article article, int[] categoriesList);
        List<Article> GetAllArticles(String category = null, String searchText = null);
        List<ArticleTitle> GetArticlesTitles();
        List<Category> GetAllCategories();
        Article GetArticleById(int id);
    }
}

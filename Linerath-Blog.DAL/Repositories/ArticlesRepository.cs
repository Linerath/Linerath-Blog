using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Dapper;

namespace Linerath_Blog.DAL.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private String connectionString;

        public ArticlesRepository(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Article> GetAllArticles(string category = null, string searchText = null, bool? caseSensetive = null)
        {
            String additionalCondition = "";

            // Additional condition for searching and filtering.
            if (!String.IsNullOrWhiteSpace(searchText))
            {
                // Taken from StackOverflow.
                searchText = "%" + searchText.Replace("[", "[[]").Replace("%", "[%]") + "%";
                if (!String.IsNullOrWhiteSpace(category))
                {
                    additionalCondition = "WHERE EXISTS (" +
                      "SELECT Id FROM ArticlesCategories ac " +
                      "WHERE ac.Article_Id=t1.Id AND EXISTS (" +
                        "SELECT Id FROM Categories c " +
                        "WHERE c.Id=ac.Category_Id AND c.Name=@category AND (c.Name LIKE @searchText OR t1.Title LIKE @searchText OR t1.Body Like @searchText)" +
                      ")" +
                    ") ";
                }
                else
                {
                    additionalCondition = "WHERE EXISTS (" +
                      "SELECT Id FROM ArticlesCategories ac " +
                      "WHERE ac.Article_Id=t1.Id AND EXISTS (" +
                        "SELECT Id FROM Categories c " +
                        "WHERE c.Id=ac.Category_Id AND (c.Name LIKE @searchText OR t1.Title LIKE @searchText OR t1.Body Like @searchText)" +
                      ")" +
                    ") ";
                }
            }
            else
            {
                if (category != null)
                    additionalCondition = "WHERE EXISTS (" +
                      "SELECT Id FROM ArticlesCategories ac " +
                      "WHERE ac.Article_Id=t1.Id AND EXISTS (SELECT Id FROM Categories c WHERE c.Id=ac.Category_Id AND c.Name=@category)" +
                    ") ";
            }

            string sql = "SELECT t1.*, t2.* FROM Articles t1 "
                + "INNER JOIN ArticlesCategories t1t2 ON t1.Id=t1t2.Article_Id "
                + "INNER JOIN Categories t2 ON t2.Id=t1t2.Category_Id "
                + additionalCondition
                + "ORDER BY t1.CreationDate DESC"
                ;

            using (var connection = new SqlConnection(connectionString))
            {
                List<Article> result = new List<Article>();

                connection
                    .Query<Article, Category, Article>(sql,
                    (_article, _category) =>
                    {
                        Article existing = result.FirstOrDefault(x => x.Id == _article.Id);
                        if (existing == null)
                        {
                            _article.Categories.Add(_category);
                            result.Add(_article);
                        }
                        else
                        {
                            existing.Categories.Add(_category);
                        }

                        return _article;
                    }, new { category, searchText });

                return result;

                //Stopwatch stopwatch = Stopwatch.StartNew();
                //stopwatch.Stop();
                //var so = stopwatch.ElapsedMilliseconds;

                //List<Article> result = connection
                //    .Query<Article, Category, Article>(sql,
                //    (_article, _category) =>
                //    {
                //        _article.Categories.Add(_category);
                //        return _article;
                //    })
                //    .GroupBy(article => article.Id)
                //    .Select(group =>
                //    {
                //        Article article = group.FirstOrDefault();
                //        article.Categories = group.Select(_category => _category.Categories.Single()).ToList();
                //        return article;
                //    })
                //    .ToList();
            }
        }

        public List<ArticleTitle> GetArticlesTitles()
        {
            string sql = "SELECT t1.Id, t1.Title, t1.CreationDate, t2.* FROM Articles t1 "
                + "INNER JOIN ArticlesCategories t1t2 ON t1.Id=t1t2.Article_Id "
                + "INNER JOIN Categories t2 ON t2.Id=t1t2.Category_Id "
                + "ORDER BY t1.CreationDate DESC "
                ;

            using (var connection = new SqlConnection(connectionString))
            {
                List<ArticleTitle> result = new List<ArticleTitle>();

                connection
                    .Query<ArticleTitle, Category, ArticleTitle>(sql,
                    (_article, _category) =>
                    {
                        ArticleTitle existing = result.FirstOrDefault(x => x.Id == _article.Id);
                        if (existing == null)
                        {
                            _article.Categories.Add(_category);
                            result.Add(_article);
                        }
                        else
                            existing.Categories.Add(_category);

                        return _article;
                    });

                return result;
            }
        }

        public Article GetArticleById(int id)
        {
            string sql = "SELECT t1.*, t2.* FROM Articles t1 "
                + "INNER JOIN ArticlesCategories t1t2 ON t1.Id=t1t2.Article_Id "
                + "INNER JOIN Categories t2 ON t2.Id=t1t2.Category_Id "
                + "WHERE t1.Id=@id"
                ;

            using (var connection = new SqlConnection(connectionString))
            {
                Article result = null;

                connection
                    .Query<Article, Category, Article>(sql,
                    (article, category) =>
                    {
                        if (result == null)
                            result = article;

                        result.Categories.Add(category);

                        return article;
                    }, new { id });

                return result;
            }
        }

        public List<Category> GetAllCategories()
        {
            string sql = "SELECT * FROM Categories";

            using (var connection = new SqlConnection(connectionString))
            {
                List<Category> result = connection.Query<Category>(sql).ToList();

                return result;
            }
        }
    }
}

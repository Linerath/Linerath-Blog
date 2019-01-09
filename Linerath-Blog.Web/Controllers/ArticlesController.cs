using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.Services;
using Linerath_Blog.Web.ViewModels;

namespace Linerath_Blog.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticlesRepository articleRepository;

        public ArticlesController(IArticlesRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ViewResult All(int page = 1, String category = null, String searchText = null, bool? caseSensetive = null)
        {
            ArticlesSummariesViewModel model = new ArticlesSummariesViewModel(category, searchText, caseSensetive);

            List<Article> articles = articleRepository.GetAllArticles(category, searchText, caseSensetive);
            
            model.PaginationModel = PaginationService.GetDefaultPaginationModel(articles, page);
            articles = PaginationService.Paginate(articles, page).ToList();
            ArticleService.TrucateArticles(articles);

            articles.ForEach(x => model.Articles.Add(x));

            return View(model);
        }

        public ViewResult Article(int id, String returnUri, String category = null, String searchText = null, bool? caseSensetive = null)
        {
            Article article = articleRepository.GetArticleById(id);
            ArticleDetailsViewModel model = new ArticleDetailsViewModel(category, searchText, caseSensetive)
            {
                Article = article,
                ReturnUri = returnUri,
            };

            return View(model);
        }
    }
}
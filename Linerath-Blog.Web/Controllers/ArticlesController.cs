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
        private readonly IUnitOfWork unitOfWork;

        public ArticlesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ViewResult All(int page = 1)
        {
            ArticlesSummariesViewModel model = new ArticlesSummariesViewModel();

            List<Article> articles = unitOfWork.ArticleRepository.GetAllArticles();

            model.PaginationModel = PaginationService.GetDefaultPaginationModel(articles, page);
            articles = PaginationService.Paginate(articles, page).ToList();

            articles.ForEach(x => model.Articles.Add(x));

            return View(model);
        }

        public ViewResult Article(int id, String returnUri)
        {
            Article article = unitOfWork.ArticleRepository.GetArticleById(id);
            ArticleDetailsViewModel model = new ArticleDetailsViewModel
            {
                Article = article,
                ReturnUri = returnUri,
            };

            var lines = model.Article.Body.Split('\r', '\n');

            return View(model);
        }
    }
}
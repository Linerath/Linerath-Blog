using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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
            List<Article> articles = unitOfWork.ArticleRepository.GetAllArticles();
            articles = PaginationService.Paginate(articles, page).ToList();

            List<ArticleSummaryViewModel> model = new List<ArticleSummaryViewModel>();
            foreach (var item in articles)
                model.Add(new ArticleSummaryViewModel { Article = item });

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
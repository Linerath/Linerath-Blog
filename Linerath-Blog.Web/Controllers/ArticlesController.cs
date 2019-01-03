using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
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

        public ViewResult All()
        {
            List<Article> articles = unitOfWork.ArticleRepository.GetAllArticles();

            List<ArticleSummaryViewModel> model = Mapper.Map<List<Article>, List<ArticleSummaryViewModel>>(articles);

            return View(model);
        }

        public ViewResult Article(int id, String returnUri)
        {
            Article article = unitOfWork.ArticleRepository.GetArticleById(id);
            ArticleDetailsViewModel model = Mapper.Map<Article, ArticleDetailsViewModel>(article);
            model.ReturnUri = returnUri;

            return View(model);
        }
    }
}
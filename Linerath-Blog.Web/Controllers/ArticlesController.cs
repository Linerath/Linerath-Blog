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

        public ViewResult All(int page = 1, String category = null, String searchText = null, bool caseSensetive = false)
        {
            ViewBag.SearchText = searchText;
            ViewBag.CaseSensetive = caseSensetive;

            ArticlesSummariesViewModel model = new ArticlesSummariesViewModel
            {
                Category = category,
            };

            List<Article> articles = unitOfWork.ArticleRepository.GetAllArticles(category, searchText, caseSensetive);

            model.PaginationModel = PaginationService.GetDefaultPaginationModel(articles, page);
            articles = PaginationService.Paginate(articles, page).ToList();
            ArticleService.TrucateArticles(articles);

            articles.ForEach(x => model.Articles.Add(x));

            return View(model);
        }

        public ViewResult Article(int id, String returnUri, String searchText = null)
        {
            Article article = unitOfWork.ArticleRepository.GetArticleById(id);
            ArticleDetailsViewModel model = new ArticleDetailsViewModel
            {
                Article = article,
                ReturnUri = returnUri,
            };

            return View(model);
        }
    }
}
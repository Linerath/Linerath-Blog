﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.Enums;
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

        public ViewResult All(int page = 1, String category = null, String searchText = null)
        {
            ArticlesSummariesViewModel model = new ArticlesSummariesViewModel(category, searchText);

            List<Article> articles = articleRepository.GetAllArticles(category: category, searchText: searchText);

            model.PaginationModel = PaginationService.GetDefaultPaginationModel(articles, page);
            articles = PaginationService.Paginate(articles, page).ToList();

            model.Articles = articles;

            return View(model);
        }

        public ViewResult Article(int id, String returnUri, String category = null, String searchText = null)
        {
            Article article = articleRepository.GetArticleById(id);
            ArticleDetailsViewModel model = new ArticleDetailsViewModel(category, searchText)
            {
                Article = article,
                ReturnUri = returnUri,
            };

            return View(model);
        }

        public ViewResult Archive(ArchiveFilter filter = ArchiveFilter.Alphabet)
        {
            ArchiveArticlesViewModel model = new ArchiveArticlesViewModel(null, null)
            {
                Filter = filter,
            };

            List<ArticleTitle> articles = articleRepository.GetArticlesTitles();

            model.ArticlesGroups = ArticleService.GroupArticles(articles, filter);

            return View(model);
        }

        [HttpGet]
        public ViewResult NewArticle()
        {
            List<Category> data = articleRepository.GetAllCategories();
            CategoriesListViewModel model = new CategoriesListViewModel(null, null)
            {
                Categories = data,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult NewArticle(NewArticleViewModel data)
        {
            Article article = new Article
            {
                Title = data.Title,
                Body = data.Body,
                Summary = data.Summary,
            };

            article = ArticleService.FormatArticle(article);
            article.CreationDate = DateTime.Now;

            int id = articleRepository.AddArticle(article, data.Categories);

            if (id > 0)
                return RedirectToAction("Article", new { id });
            else
                return new HttpStatusCodeResult(500);
        }
    }
}

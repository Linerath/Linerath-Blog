﻿using System;
using AutoMapper;
using System.Web.Mvc;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.Services;
using Linerath_Blog.Web.ViewModels;
using Linerath_Blog.Web.Models;

namespace Linerath_Blog.Web.Controllers
{
    public class NavigationController : Controller
    {
        private IArticlesRepository articleRepository;

        public NavigationController(IArticlesRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [ChildActionOnly]
        public PartialViewResult Navbar(String category = null, String searchText = null)
        {
            List<Category> categories = articleRepository.GetAllCategories();
            List<Article> articles = articleRepository.GetAllArticles();

            MenuCategoriesListViewModel model = new MenuCategoriesListViewModel(category, searchText)
            {
                Categories = Mapper.Map<List<Category>, List<MenuCategoryModel>>(categories),
            };

            ArticleService.CalculateCategoriesCount(model.Categories, articles);

            return PartialView("NavbarPartial", model);
        }

        public PartialViewResult MenuLeft(String category = null, String searchText = null)
        {
            List<Category> categories = articleRepository.GetAllCategories();
            List<Article> articles = articleRepository.GetAllArticles();

            MenuCategoriesListViewModel model = new MenuCategoriesListViewModel(category, searchText)
            {
                Categories = Mapper.Map<List<Category>, List<MenuCategoryModel>>(categories),
            };

            ArticleService.CalculateCategoriesCount(model.Categories, articles);

            return PartialView("MenuLeftPartial", model);
        }

        public PartialViewResult MenuRight()
        {
            List<MenuRightViewModel> model = new List<MenuRightViewModel>();

            return PartialView("MenuRightPartial", model);
        }
    }
}
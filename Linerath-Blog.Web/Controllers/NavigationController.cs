using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.Services;
using Linerath_Blog.Web.ViewModels;
using Linerath_Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class NavigationController : Controller
    {
        private IArticlesRepository articleRepository;

        public NavigationController(IArticlesRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public PartialViewResult MenuLeft(String searchText = null, bool caseSensetive = false)
        {
            List<Category> categories = articleRepository.GetAllCategories();
            List<Article> articles = articleRepository.GetAllArticles();

            CategoriesListViewModel model = new CategoriesListViewModel
            {
                Categories = Mapper.Map<List<Category>, List<CategoryModel>>(categories),
                SearchText = searchText,
                CaseSensetive = caseSensetive,
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
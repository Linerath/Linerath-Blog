using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public NavigationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PartialViewResult MenuLeft()
        {
            List<Category> categories = unitOfWork.ArticleRepository.GetAllCategories();

            List<CategoryViewModel> model = Mapper.Map<List<Category>, List<CategoryViewModel>>(categories);

            return PartialView("MenuLeftPartial", model);
        }

        public PartialViewResult MenuRight()
        {
            List<MenuRightViewModel> model = new List<MenuRightViewModel>();

            return PartialView("MenuRightPartial", model);
        }
    }
}
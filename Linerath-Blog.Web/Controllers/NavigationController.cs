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
            List<MenuLeftViewModel> model = new List<MenuLeftViewModel>()
            {
                new MenuLeftViewModel{ Name = "Life (0)" },
                new MenuLeftViewModel{ Name = "Random thoughts (1)" },
            };

            return PartialView("MenuLeftPartial", model);
        }

        public PartialViewResult MenuRight()
        {
            List<MenuRightViewModel> model = new List<MenuRightViewModel>();

            return PartialView("MenuRightPartial", model);
        }
    }
}
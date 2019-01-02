using Linerath_Blog.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class NavigationController : Controller
    {
        public PartialViewResult MenuLeft()
        {
            List<MenuLeftViewModel> model = new List<MenuLeftViewModel>()
            {
                new MenuLeftViewModel{ Name = "test0" },
                new MenuLeftViewModel{ Name = "test1" },
            };

            return PartialView("MenuLeftPartial", model);
        }

        public PartialViewResult MenuRight()
        {
            List<MenuRightViewModel> model = new List<MenuRightViewModel>()
            {
                new MenuRightViewModel{ Name = "another test0" },
                new MenuRightViewModel{ Name = "another test1" },
            };

            return PartialView("MenuRightPartial", model);
        }
    }
}
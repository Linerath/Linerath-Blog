using System;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Home()
        {
            //Services.ArticleService.FormatArticle(
            //    @"D:\Articles Test\lorem ipsum.txt",
            //    @"D:\Articles Test\lorem ipsum summ.txt",
            //    "Lorem ipsum",
            //    new DateTime(2019, 1, 31, 14, 2, 0)
            //);

            return View();
        }
    }
}

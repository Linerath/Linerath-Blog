//#define format
using System;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Home()
        {
#if format
            Services.ArticleService.FormatArticle(
                "Lorem ipsum",
                @"D:\Articles Test\lorem.txt",
                @"D:\Articles Test\lorem s.txt",
                new DateTime(2019, 1, 31, 14, 2, 0)
            );
            Services.ArticleService.FormatArticle(
                "Slipknot - Eyeless",
                @"D:\Articles Test\slip.txt",
                @"D:\Articles Test\slip s.txt",
                new DateTime(2018, 12, 31, 18, 0, 0)
            );
            Services.ArticleService.FormatArticle(
                "Portal - Still Alive",
                @"D:\Articles Test\sa.txt",
                @"D:\Articles Test\sa s.txt",
                new DateTime(2019, 1, 29, 17, 26, 0)
            );
            Services.ArticleService.FormatArticle(
                "Ghost - I'm A Marionette",
                @"D:\Articles Test\marionette.txt",
                @"D:\Articles Test\marionette s.txt",
                new DateTime(2019, 1, 15, 8, 41, 0)
            );
            Services.ArticleService.FormatArticle(
                "ABBA - Money Money Money",
                @"D:\Articles Test\money.txt",
                @"D:\Articles Test\money s.txt",
                new DateTime(2019, 1, 13, 15, 0, 0)
            );
#endif

            return View();
        }
    }
}

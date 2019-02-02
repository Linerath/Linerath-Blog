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
                @"D:\Articles Test\lorem.txt",
                @"D:\Articles Test\lorem s.txt",
                "Lorem ipsum",
                new DateTime(2019, 1, 31, 14, 2, 0)
            );
            Services.ArticleService.FormatArticle(
                @"D:\Articles Test\slip.txt",
                @"D:\Articles Test\slip s.txt",
                "Slipknot - Eyeless",
                new DateTime(2018, 12, 31, 18, 0, 0)
            );
            Services.ArticleService.FormatArticle(
                @"D:\Articles Test\sa.txt",
                @"D:\Articles Test\sa s.txt",
                "Portal - Still Alive",
                new DateTime(2019, 1, 29, 17, 26, 0)
            );
            Services.ArticleService.FormatArticle(
                @"D:\Articles Test\marionette.txt",
                @"D:\Articles Test\marionette s.txt",
                "Ghost - I'm A Marionette",
                new DateTime(2019, 1, 15, 8, 41, 0)
            );
            Services.ArticleService.FormatArticle(
                @"D:\Articles Test\money.txt",
                @"D:\Articles Test\money s.txt",
                "ABBA - Money Money Money",
                new DateTime(2019, 1, 13, 15, 0, 0)
            );
#endif

            return View();
        }
    }
}

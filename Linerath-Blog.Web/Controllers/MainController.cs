using Linerath_Blog.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Home()
        {
            List<NoteSummaryViewModel> model = new List<NoteSummaryViewModel>
            {
                new NoteSummaryViewModel
                {
                    Title = "Welcome",
                    Body = "To my in-development blog. I'm so excited about that idea.",
                    CreationDate = DateTime.Now
                },
                new NoteSummaryViewModel
                {
                    Title = "Eyeless",
                    Body = @"Insane - Am I the only motherfucker with a brain?
                             I'm hearing voices but all they do is complain
                             How many times have you wanted to kill
                             Everything and everyone - Say you'll do it but never will
                             
                             You can't see California without Marlon Brando's eyes
                             Can't see California without Marlon Brando's eyes
                             You can't see California without Marlon Brando's eyes",
                    CreationDate = DateTime.Now
                },
                new NoteSummaryViewModel
                {
                    Title = "Кликбейтный заголовок!",
                    Body = "Заголовок кликбейтный, а содержание - пустышка.",
                    CreationDate = DateTime.Now,
                }
            };

            return View(model);
        }
    }
}
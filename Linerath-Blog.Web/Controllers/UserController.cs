using Linerath_Blog.Web.Infrastructure.Interfaces;
using Linerath_Blog.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class UserController : Controller
    {
        private IAuthProvider authProvider;

        public UserController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, String returnUri)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Username, model.Password))
                {
                    return Redirect(returnUri);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or/and password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
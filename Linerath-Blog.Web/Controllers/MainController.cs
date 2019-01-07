using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
    }
}
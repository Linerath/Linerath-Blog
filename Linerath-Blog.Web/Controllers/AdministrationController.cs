using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
    }
}
using Linerath_Blog.DAL.Interfaces;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class MainController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MainController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ViewResult Home()
        {
            return View();
        }
    }
}
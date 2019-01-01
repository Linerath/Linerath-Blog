using Linerath_Blog.Web.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Linerath_Blog.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule ninjectModule = new NinjectDependencies();
            var kernel = new StandardKernel(ninjectModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

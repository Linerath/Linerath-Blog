using System.Web.Mvc;
using System.Web.Routing;

namespace Linerath_Blog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "{category}",
                defaults: new { controller = "Articles", action = "All" }
            );

            routes.MapRoute(
                name: "",
                url: "Article/{id}",
                defaults: new { controller = "Articles", action = "Article" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Main", action = "Home" }
            );
        }
    }
}

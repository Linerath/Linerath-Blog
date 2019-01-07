using Ninject.Modules;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.DAL.Repositories;
using System.Configuration;

namespace Linerath_Blog.Web.Infrastructure
{
    public class NinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticlesRepository>().To<ArticlesRepository>()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
        }
    }
}
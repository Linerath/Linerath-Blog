using System;
using System.Configuration;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.DAL.Repositories;
using Linerath_Blog.Web.Infrastructure.Implementations;
using Linerath_Blog.Web.Infrastructure.Interfaces;
using Ninject.Modules;

namespace Linerath_Blog.Web.Infrastructure
{
    public class NinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;

            Bind<IArticlesRepository>().To<ArticlesRepository>()
                .WithConstructorArgument(nameof(connectionString), connectionString);
            Bind<ICommentsRepository>().To<CommentsRepository>()
                .WithConstructorArgument(nameof(connectionString), connectionString);
            Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
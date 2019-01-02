using Ninject.Modules;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.DAL.Repositories;

namespace Linerath_Blog.Web.Infrastructure
{
    public class NinjectDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
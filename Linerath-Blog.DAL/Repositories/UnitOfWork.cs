using Linerath_Blog.DAL.Interfaces;

namespace Linerath_Blog.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MockArticleRepository articleRepository;

        public IArticleRepository ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new MockArticleRepository();

                return articleRepository;
            }
        }
    }
}

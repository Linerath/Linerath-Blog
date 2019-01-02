namespace Linerath_Blog.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
    }
}

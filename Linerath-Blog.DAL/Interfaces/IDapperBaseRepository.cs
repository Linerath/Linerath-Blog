using System;
using System.Data;

namespace Linerath_Blog.DAL.Interfaces
{
    public interface IDapperBaseRepository
    {
        void Execute(Action<IDbConnection> query);
    }
}

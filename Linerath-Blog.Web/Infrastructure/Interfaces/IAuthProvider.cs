using System;

namespace Linerath_Blog.Web.Infrastructure.Interfaces
{
    public interface IAuthProvider
    {
        bool Authenticate(String username, String password);
    }
}

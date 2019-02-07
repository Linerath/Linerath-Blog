using Linerath_Blog.Web.Infrastructure.Interfaces;
using System.Web.Security;

namespace Linerath_Blog.Web.Infrastructure.Implementations
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}
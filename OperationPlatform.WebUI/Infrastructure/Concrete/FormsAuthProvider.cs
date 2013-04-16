using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add new references
using OperationPlatform.WebUI.Infrastructure.Abstract;
using System.Web.Security;

namespace OperationPlatform.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}
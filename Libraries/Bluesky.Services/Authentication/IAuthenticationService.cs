using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(Account customer, bool createPersistentCookie);
        void SignOut();
        Account GetAuthenticatedAccount();
    }
}

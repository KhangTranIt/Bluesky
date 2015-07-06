using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public interface IAccountRegistrationService
    {
        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        AccountRegistrationResult RegisterAccount(AccountRegistrationRequest request);

        AccountLoginResults ValidateAccount(string email, string password);
        PasswordChangeResult ChangePassword(ChangePasswordRequest request);
    }
}

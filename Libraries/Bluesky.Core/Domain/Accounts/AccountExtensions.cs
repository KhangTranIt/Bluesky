using System;
using System.Linq;

namespace Bluesky.Core.Domain.Accounts
{
    public static class AccountExtensions
    {
        public static bool IsInAccountRole(this Account account,
            string accountRoleSystemName, bool onlyActiveCustomerRoles = true)
        {
            if (account == null)
                throw new ArgumentNullException("account");

            if (String.IsNullOrEmpty(accountRoleSystemName))
                throw new ArgumentNullException("accountRoleSystemName");

            var result = account.AccountRoles
                .FirstOrDefault(ar => (!onlyActiveCustomerRoles || ar.Active) && (ar.SystemName == accountRoleSystemName)) != null;
            return result;
        }
        public static bool IsRegistered(this Account customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInAccountRole(customer, SystemAccountRoleNames.Registered, onlyActiveCustomerRoles);
        }
    }
}

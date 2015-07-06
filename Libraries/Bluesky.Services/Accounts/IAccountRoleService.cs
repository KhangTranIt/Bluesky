using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public interface IAccountRoleService
    {
        AccountRole GetAccountRoleById(int accountRoleId);
        IEnumerable<AccountRole> GetAllAccountRole();
        void InsertAccountRole(AccountRole accountRole);
        void UpdateAccountRole(AccountRole accountRole);
        void DeleteAccountRole(AccountRole accountRole);
    }
}

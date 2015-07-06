using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Data;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public class AccountRoleService : IAccountRoleService
    {
        private readonly IRepository<AccountRole> _accountRoleRepository;

        public AccountRoleService(IRepository<AccountRole> accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        public AccountRole GetAccountRoleById(int accountRoleId)
        {
            if (accountRoleId == 0)
                return null;
            return _accountRoleRepository.Table.FirstOrDefault(p => p.Id == accountRoleId);
        }

        public IEnumerable<AccountRole> GetAllAccountRole()
        {
            return _accountRoleRepository.Table.AsEnumerable();
        }

        public void InsertAccountRole(AccountRole accountRole)
        {
            if(accountRole == null)
                throw new ArgumentNullException("accountRole");

            _accountRoleRepository.Insert(accountRole);
        }

        public void UpdateAccountRole(AccountRole accountRole)
        {
            if (accountRole == null)
                throw new ArgumentNullException("accountRole");

            _accountRoleRepository.Update(accountRole);
        }

        public void DeleteAccountRole(AccountRole accountRole)
        {
            if (accountRole == null)
                throw new ArgumentNullException("accountRole");

            _accountRoleRepository.Delete(accountRole);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Data;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<AccountRole> _accountRoleRepository;

        public AccountService(IRepository<Account> accountRepository, 
            IRepository<AccountRole> accountRoleRepository)
        {
            _accountRepository = accountRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        public Account GetAccountBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(int accountId)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByGuid(Guid accountGuid)
        {
            if (accountGuid == Guid.Empty)
                return null;

            var query = from c in _accountRepository.Table
                        where c.AccountGuid == accountGuid
                        orderby c.Id
                        select c;
            var account = query.FirstOrDefault();
            return account;
        }

        public Account InsertGuestAccount()
        {
            var account = new Account()
            {
                AccountGuid = Guid.NewGuid(),
                Active = true,
                CreatedOnUtc = DateTime.UtcNow,
                LastActivityDateUtc = DateTime.UtcNow,
                Birthdate = DateTime.UtcNow,
            };

            //add to 'Guests' role
            var guestRole = GetAccountRoleBySystemName(SystemAccountRoleNames.Guests);
            if (guestRole == null)
                throw new Exception("'Guests' role could not be loaded");
            account.AccountRoles.Add(guestRole);
            _accountRepository.Insert(account);

            return account;
        }

        public Account GetAccountByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _accountRepository.Table
                        orderby c.Id
                        where c.Email == email
                        select c;
            var account = query.FirstOrDefault();
            return account;
        }

        /// <summary>
        /// Gets a account role
        /// </summary>
        /// <param name="systemName">Account role system name</param>
        /// <returns>Account role</returns>
        public AccountRole GetAccountRoleBySystemName(string systemName)
        {
            if (String.IsNullOrWhiteSpace(systemName))
                return null;
            var query = from cr in _accountRoleRepository.Table
                        orderby cr.Id
                        where cr.SystemName == systemName
                        select cr;
            var accountRole = query.FirstOrDefault();
            return accountRole;
        }

        public void UpdateAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");

            _accountRepository.Update(account);
        }

        public void CreateAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");

            _accountRepository.Insert(account);
        }


        public List<Account> GetAllAccount()
        {
            var query = from c in _accountRepository.Table
                        orderby c.Id
                     
                        select c;

            return query.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        Account GetAccountBySystemName(string systemName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Account GetAccountById(int accountId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountGuid"></param>
        /// <returns></returns>
        Account GetAccountByGuid(Guid accountGuid);

        /// <summary>
        /// 
        /// </summary>
        Account InsertGuestAccount();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Account GetAccountByEmail(string email);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        AccountRole GetAccountRoleBySystemName(string systemName);
        /// <summary>
        /// Updates the account
        /// </summary>
        /// <param name="account">Account</param>
        void UpdateAccount(Account account);


        /// <summary>
        /// Create the account
        /// </summary>
        /// <param name="account">Account</param>
        void CreateAccount(Account account);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         List<Account> GetAllAccount();
    }
}

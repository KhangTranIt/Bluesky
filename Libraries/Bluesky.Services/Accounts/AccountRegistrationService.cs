using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core;
using Bluesky.Core.Domain.Accounts;
using Bluesky.Services.Security;

namespace Bluesky.Services.Accounts
{
    public class AccountRegistrationService : IAccountRegistrationService
    {
        private readonly IAccountService _accountService;
        private readonly IEncryptionService _encryptionService;

        public AccountRegistrationService(IAccountService accountService, IEncryptionService encryptionService)
        {
            _accountService = accountService;
            _encryptionService = encryptionService;
        }

        public AccountRegistrationResult RegisterAccount(AccountRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Account == null)
                throw new ArgumentException("Can't load current account");

            var result = new AccountRegistrationResult();

            if (request.Account.IsRegistered())
            {
                result.AddError("Current account is already registered");
                return result;
            }
            if (String.IsNullOrEmpty(request.Email))
            {
                result.AddError("Email Is Not Provided");
                return result;
            }
            if (!CommonHelper.IsValidEmail(request.Email))
            {
                result.AddError("Common.WrongEmail");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.Password))
            {
                result.AddError("Account.Register.Errors.PasswordIsNotProvided");
                return result;
            }

            //validate unique user
            if (_accountService.GetAccountByEmail(request.Email) != null)
            {
                result.AddError("Account.Register.Errors.EmailAlreadyExists");
                return result;
            }

            //at this point request is valid
            request.Account.Email = request.Email;
            request.Account.PasswordFormat = request.PasswordFormat;

            switch (request.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    {
                        request.Account.Password = request.Password;
                    }
                    break;
                case PasswordFormat.Encrypted:
                    {
                        request.Account.Password = _encryptionService.EncryptText(request.Password);
                    }
                    break;
                case PasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        request.Account.PasswordSalt = saltKey;
                        request.Account.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey);
                    }
                    break;
                default:
                    break;
            }

            request.Account.Active = true;

            //add to 'Registered' role
            var registeredRole = _accountService.GetAccountRoleBySystemName(SystemAccountRoleNames.Registered);
            if (registeredRole == null)
                throw new Exception("'Registered' role could not be loaded");
            request.Account.AccountRoles.Add(registeredRole);
            //remove from 'Guests' role
            var guestRole =
                request.Account.AccountRoles.FirstOrDefault(cr => cr.SystemName == SystemAccountRoleNames.Guests);
            if (guestRole != null)
                request.Account.AccountRoles.Remove(guestRole);

            _accountService.UpdateAccount(request.Account);
            return result;
        }

        /// <summary>
        /// Validate account
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual AccountLoginResults ValidateAccount(string email, string password)
        {
            var account = _accountService.GetAccountByEmail(email);

            if (account == null)
                return AccountLoginResults.AccountNotExist;
            if (account.Deleted)
                return AccountLoginResults.Deleted;
            //only registered can login
            if (!account.IsRegistered())
                return AccountLoginResults.NotRegistered;

            string pwd = "";
            switch (account.PasswordFormat)
            {
                case PasswordFormat.Encrypted:
                    pwd = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    pwd = _encryptionService.CreatePasswordHash(password, account.PasswordSalt);
                    break;
                default:
                    pwd = password;
                    break;
            }
            bool isValid = pwd == account.Password;

            //save last login date
            if (isValid)
            {
                account.LastLoginDateUtc = DateTime.UtcNow;
                _accountService.UpdateAccount(account);
                return AccountLoginResults.Successful;
            }
            else
                return AccountLoginResults.WrongPassword;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual PasswordChangeResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var result = new PasswordChangeResult();
            if (String.IsNullOrWhiteSpace(request.Email))
            {
                result.AddError("Email is not provided");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.NewPassword))
            {
                result.AddError("Password is not provided");
                return result;
            }

            var account = _accountService.GetAccountByEmail(request.Email);
            if (account == null)
            {
                result.AddError("Email not found");
                return result;
            }

            var requestIsValid = false;
            if (request.ValidateRequest)
            {
                //password
                string oldPwd = "";
                switch (account.PasswordFormat)
                {
                    case PasswordFormat.Encrypted:
                        oldPwd = _encryptionService.EncryptText(request.OldPassword);
                        break;
                    case PasswordFormat.Hashed:
                        oldPwd = _encryptionService.CreatePasswordHash(request.OldPassword, account.PasswordSalt);
                        break;
                    default:
                        oldPwd = request.OldPassword;
                        break;
                }

                bool oldPasswordIsValid = oldPwd == account.Password;
                if (!oldPasswordIsValid)
                    result.AddError("Old password doesn't match");

                if (oldPasswordIsValid)
                    requestIsValid = true;
            }
            else
                requestIsValid = true;


            //at this point request is valid
            if (requestIsValid)
            {
                switch (request.NewPasswordFormat)
                {
                    case PasswordFormat.Clear:
                        {
                            account.Password = request.NewPassword;
                        }
                        break;
                    case PasswordFormat.Encrypted:
                        {
                            account.Password = _encryptionService.EncryptText(request.NewPassword);
                        }
                        break;
                    case PasswordFormat.Hashed:
                        {
                            string saltKey = _encryptionService.CreateSaltKey(5);
                            account.PasswordSalt = saltKey;
                            account.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey);
                        }
                        break;
                    default:
                        break;
                }
                account.PasswordFormat = request.NewPasswordFormat;
                _accountService.UpdateAccount(account);
            }

            return result;
        }
    }
}

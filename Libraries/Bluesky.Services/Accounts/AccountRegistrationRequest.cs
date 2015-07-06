using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public class AccountRegistrationRequest
    {
        public Account Account { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PasswordFormat PasswordFormat { get; set; }

        public AccountRegistrationRequest(Account account, string email,string password,PasswordFormat passwordFormat)
        {
            Account = account;
            Email = email;
            Password = password;
            PasswordFormat = passwordFormat;
        }
    }
}

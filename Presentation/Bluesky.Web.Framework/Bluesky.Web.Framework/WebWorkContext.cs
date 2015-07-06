using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Bluesky.Core;
using Bluesky.Core.Domain.Accounts;
using Bluesky.Core.Fakes;
using Bluesky.Services.Accounts;
using Bluesky.Services.Authentication;

namespace Bluesky.Web.Framework
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        private const string AccountCookieName = "Bluesky.customer";

        private readonly HttpContextBase _httpContext;
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;

        private Account _cachedAccount;
        private Account _originalAccountIfImpersonated;
        public WebWorkContext(HttpContextBase httpContext, 
            IAccountService accountService, 
            IAuthenticationService authenticationService)
        {
            _httpContext = httpContext;
            _accountService = accountService;
            _authenticationService = authenticationService;
        }

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[AccountCookieName];
        }

        protected virtual void SetCustomerCookie(Guid accountGuid)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(AccountCookieName);
                cookie.HttpOnly = true;
                cookie.Value = accountGuid.ToString();
                if (accountGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 365; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(AccountCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }

        public Account CurrentAccount
        {
            get
            {

                Account account = null;
                if (_httpContext == null || _httpContext is FakeHttpContext)
                {
                    //check whether request is made by a background task
                    //in this case return built-in customer record for background task
                    account = _accountService.GetAccountBySystemName(SystemCustomerNames.BackgroundTask);
                }

                //registered user
                if (account == null || account.Deleted || !account.Active)
                {
                    account = _authenticationService.GetAuthenticatedAccount();
                }

                //load guest customer
                if (account == null || account.Deleted || !account.Active)
                {
                    var customerCookie = GetCustomerCookie();
                    if (customerCookie != null && !String.IsNullOrEmpty(customerCookie.Value))
                    {
                        Guid customerGuid;
                        if (Guid.TryParse(customerCookie.Value, out customerGuid))
                        {
                            var customerByCookie = _accountService.GetAccountByGuid(customerGuid);
                            if (customerByCookie != null &&
                                //this customer (from cookie) should not be registered
                                !customerByCookie.IsRegistered())
                                account = customerByCookie;
                        }
                    }
                }

                _cachedAccount = account;
                //create guest if not exists
                if (account == null || account.Deleted || !account.Active)
                {
                    //account = _accountService.InsertGuestAccount();
                    SetCustomerCookie(Guid.Empty);
                    return null;
                    
                }
                //validation
                if (!account.Deleted && account.Active)
                {
                    SetCustomerCookie(account.AccountGuid);
                }

                return _cachedAccount;
            }
            set
            {
                SetCustomerCookie(value.AccountGuid);
            }
        }
    }
}

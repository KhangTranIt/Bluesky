using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluesky.Core;
using Bluesky.Core.Data;
using Bluesky.Core.Domain.Accounts;
using Bluesky.Services.Accounts;
using Bluesky.Services.Authentication;
using Bluesky.Web.Models.Account;
using CaptchaMvc.Attributes;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace Bluesky.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IWorkContext _workContext;
        private readonly IAccountService _accountService;
        private readonly IAccountRegistrationService _accountRegistrationService;
       
        public AccountController(IAuthenticationService authenticationService,
            IWorkContext workContext,
            IAccountService accountService,
            IAccountRegistrationService accountRegistrationService)
        {
            _authenticationService = authenticationService;
            _workContext = workContext;
            _accountService = accountService;
            _accountRegistrationService = accountRegistrationService;
        
     
        }
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpsRequirement(SslRequirement.Yes)]
        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

       
        [ValidateAntiForgeryToken]
        [HttpPost, CaptchaVerify("Captcha is not valid")]
        public ActionResult Register(RegisterModel model, string returnUrl, FormCollection form)
        {
            if (_workContext.CurrentAccount == null || _workContext.CurrentAccount.IsRegistered())
            {
                //Already registered customer. 
                _authenticationService.SignOut();
              
                //Save a new record
               // _workContext.CurrentAccount = _accountService.InsertGuestAccount();
            }

            var account = new Account(){
                  Birthdate = model.Birthdate,
                  Contact = model.Contact,
                Country= model.Country,
                  Email = model.Email,
                   Deleted = false,
                   Gender = model.Gender,
                   Language = model.Language,
                   CreatedOnUtc = DateTime.Now,
                   LastActivityDateUtc = DateTime.Now,
                   AccountGuid = Guid.NewGuid()

                   
            };

            
            if (ModelState.IsValid)
            {
                 
                   var registrationRequest = new AccountRegistrationRequest(account, model.Email, model.Password, PasswordFormat.Hashed);
               // _accountService.InsertGuestAccount
                var registrationResult = _accountRegistrationService.RegisterAccount(registrationRequest);
                if (registrationResult.Success)
                { _accountService.CreateAccount(account);
                  
                    _authenticationService.SignIn(account, true);
                    return RedirectToRoute("HomePage");
                }
                else
                {
                    foreach (var error in registrationResult.Errors)
                        ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            _authenticationService.SignOut();
            return RedirectToRoute("HomePage");
        }
        //[HttpsRequirement(SslRequirement.Yes)]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _accountRegistrationService.ValidateAccount(model.Email, model.Password);
                switch (loginResult)
                {
                    case AccountLoginResults.Successful:
                        {
                            var account = _accountService.GetAccountByEmail(model.Email);

                            //sign in new customer
                            _authenticationService.SignIn(account, model.RememberMe);

                            

                            if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                                return Redirect(returnUrl);
                            else
                                return RedirectToRoute("HomePage");
                        }
                    case AccountLoginResults.AccountNotExist:
                        ModelState.AddModelError("", "Account is not exist");
                        break;
                    case AccountLoginResults.Deleted:
                        ModelState.AddModelError("", "Account is deleted");
                        break;

                    case AccountLoginResults.NotRegistered:
                        ModelState.AddModelError("", "Account not registered");
                        break;
                    case AccountLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", "Wrong password");
                        break;
                }
            }
            return View(model);
        }

         [HttpPost]
        public async Task<ActionResult> UserProfile(ResetPasswordViewModel model)
        {
           // var user = _accountService.GetAccountByEmail(User.Identity.Name);
            DataSettingsHelper.ResetCache();
            var user =  _accountService.GetAccountByEmail(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            const PasswordFormat passworkFormat = new PasswordFormat();
            var changePasswordRequest = new ChangePasswordRequest(model.Email, true, passworkFormat, model.OldPassword);
            // _accountService.InsertGuestAccount
            var registrationResult = _accountRegistrationService.ChangePassword(changePasswordRequest);
            //var result = await UserManager.ResetPasswordAsync(model.Email, model.OldPassword, model.Password);
          
                return RedirectToAction("Index", "Home");
            
         
           
            return View(model);
        }
        public ActionResult UserProfile()
        {
            var model = new ResetPasswordViewModel();
            var user = User.Identity.Name;
            model.Email = user;
            return View(model);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluesky.Admin.Models.Account;
using Bluesky.Core;
using Bluesky.Core.Domain.Accounts;
using Bluesky.Services.Accounts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bluesky.Admin.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly IAccountService _AccountService;
        private readonly IWorkContext _workContext;

        public AccountManagerController(IAccountService AccountService, 
            IWorkContext workContext)
        {
            _AccountService = AccountService;
            _workContext = workContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountList([DataSourceRequest]DataSourceRequest request)
        {
            var transactions = _AccountService.GetAllAccount()
                .Select(p => new AccountModels
                                      {

                                          UserName = p.Name,
                                          Email = p.Email,
                                          Birthday = p.Birthdate.ToString(),
                                          BankName = p.BankName,
                                          CreateDate = p.CreatedOnUtc.ToShortDateString()
                                      });

            return Json(transactions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluesky.Core;
using Bluesky.Core.Domain.Accounts;
using Bluesky.Web.Models.Common;

namespace Bluesky.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly IWorkContext _workContext;

        public CommonController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public ActionResult AdminLink()
        {
            var account = _workContext.CurrentAccount;

            var model = new AdminLinkModel()
                            {
                                DisplayLink = account != null && account.AccountRoles.Any(ar => ar.SystemName == SystemAccountRoleNames.Administrators)
                            };
            return PartialView("_AdminLink", model);
        }
        public ActionResult LeftMainMenu(string activeItem)
        {
            return PartialView("_LeftMainMenu", new LeftMainMenuModel()
                                                    {
                                                        ActiveItem = activeItem,
                                                        IsLogined = _workContext.CurrentAccount != null
                                                    });
        }
    }
}
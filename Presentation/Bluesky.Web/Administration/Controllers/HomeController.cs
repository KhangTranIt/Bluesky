using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluesky.Web.Framework.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bluesky.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}

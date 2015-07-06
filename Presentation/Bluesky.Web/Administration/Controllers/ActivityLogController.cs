using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Bluesky.Admin.Models.ActivityLog;
using Bluesky.Services.Accounts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;


namespace Bluesky.Admin.Controllers
{
    public class ActivityLogController : Controller
    {

        private readonly IActivityLogService _iActivityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _iActivityLogService = activityLogService;
        }

        public ActionResult Index()
        {
            return View();
        }
       
      
        public ActionResult List([DataSourceRequest]DataSourceRequest request)
        {
            var data = _iActivityLogService.GetAllActivityLog().Select(p => new ActivityLogModel()
            {
                Id = p.Id,
                Name = p.Name,
                Comment = p.Comment,
                UpdateOn = p.UpdateOn,
                UserId = p.UserName,
                UserName = p.UserName
            });

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

      
    }
}

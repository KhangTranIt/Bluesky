using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bluesky.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("HomePage",
                            "",
                            new { controller = "Home", action = "Index" },
                            new[] { "Bluesky.Web.Controllers" });
            routes.MapRoute("AdminLink",
                            "common/adminlink",
                            new { controller = "Common", action = "AdminLink" },
                            new[] { "Bluesky.Web.Controllers" });
            routes.MapRoute("LeftMainMenu",
                            "common/leftmainmenu",
                            new {controller = "Common", action = "LeftMainMenu"},
                            new[] {"Bluesky.Web.Controllers"});
            //install
            routes.MapRoute("Installation",
                            "install",
                            new { controller = "Install", action = "Index" },
                            new[] { "Bluesky.Web.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
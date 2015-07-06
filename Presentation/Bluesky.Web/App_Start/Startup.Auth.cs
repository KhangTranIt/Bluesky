using Bluesky.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

using Owin;
using System;
[assembly: OwinStartup(typeof(Startup))]

namespace Bluesky.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            

            // Enable the application to use a cookie to store information for the signed in user
          
        }
    }
}
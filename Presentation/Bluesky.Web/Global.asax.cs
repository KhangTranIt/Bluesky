using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bluesky.Core;
using Bluesky.Core.Data;
using Bluesky.Core.Infrastructure;
using Bluesky.Web.Framework;
using FluentValidation.Mvc;
using CaptchaMvc.Infrastructure;
using CaptchaMvc.Interface;
using System.Collections.Concurrent;
namespace Bluesky.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public const string MultipleParameterKey = "_multiple_";

        private static readonly ConcurrentDictionary<int, ICaptchaManager> CaptchaManagers =
          new ConcurrentDictionary<int, ICaptchaManager>();
        protected void Application_Start()
        {
            EngineContext.Initialize(false);

            //remove all view engines
            ViewEngines.Engines.Clear();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();

            //fluent validation
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new BlueskyValidatorFactory()));
            CaptchaUtils.CaptchaManagerFactory = GetCaptchaManager;
        
        }

        private static ICaptchaManager GetCaptchaManager(IParameterContainer parameterContainer)
        {
            int numberOfCaptcha;
            if (parameterContainer.TryGet(MultipleParameterKey, out numberOfCaptcha))
                return CaptchaManagers.GetOrAdd(numberOfCaptcha, CreateCaptchaManagerByNumber);

            //If not found parameter return default manager.
            return CaptchaUtils.CaptchaManager;
        }

        private static ICaptchaManager CreateCaptchaManagerByNumber(int i)
        {
            var captchaManager = new DefaultCaptchaManager(new SessionStorageProvider());
            captchaManager.ImageElementName += i;
            captchaManager.InputElementName += i;
            captchaManager.TokenElementName += i;
            captchaManager.ImageUrlFactory = (helper, pair) =>
            {
                var dictionary = new RouteValueDictionary();
                dictionary.Add(captchaManager.TokenParameterName, pair.Key);
                dictionary.Add(MultipleParameterKey, i);
                return helper.Action("Generate", "DefaultCaptcha", dictionary);
            };
            captchaManager.RefreshUrlFactory = (helper, pair) =>
            {
                var dictionary = new RouteValueDictionary();
                dictionary.Add(MultipleParameterKey, i);
                return helper.Action("Refresh", "DefaultCaptcha", dictionary);
            };
            return captchaManager;
        }
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    //ignore static resources
        //    //var webHelper = EngineContext.Current.Resolve<IWebHelper>();
        //    //if (webHelper.IsStaticResource(this.Request))
        //    //    return;

        //    //ensure database is installed
        //    //if (!DataSettingsHelper.DatabaseIsInstalled())
        //    //{
        //    //    string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
        //    //    if (!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
        //    //    {
        //    //        this.Response.Redirect(installUrl);
        //    //    }
        //    //}

        //    if (!DataSettingsHelper.DatabaseIsInstalled())
        //        return;
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Bluesky.Core;
using Bluesky.Core.Data;
using Bluesky.Core.Fakes;
using Bluesky.Core.Infrastructure;
using Bluesky.Core.Infrastructure.DependencyManagement;
using Bluesky.Data;
using Bluesky.Services.Accounts;
using Bluesky.Services.Authentication;
using Bluesky.Services.Banks;
using Bluesky.Services.Security;

namespace Bluesky.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();

            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                builder.Register<IDbContext>(c => new BlueskyObjectContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                builder.Register<IDbContext>(c => new BlueskyObjectContext(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerLifetimeScope();
            }
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            
            builder.RegisterType<BankService>().As<IBankService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountRoleService>().As<IAccountRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<ActivityLogService>().As<IActivityLogService>().InstancePerLifetimeScope();
            
            builder.RegisterType<AccountRegistrationService>().As<IAccountRegistrationService>().InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
      
        }

        public int Order
        {
            get { return 0; }
        }
    }
}

using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using CH.Spartan.Api;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;

namespace CH.Spartan.Web
{
    [DependsOn(
        typeof(SpartanDataModule),
        typeof(SpartanApplicationModule),
        typeof(SpartanWebApiModule),
        typeof(AbpWebSignalRModule),
        typeof(AbpHangfireModule),
        typeof(AbpWebMvcModule))]
    public class SpartanWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<SpartanNavigationProvider>();

            //Configure Hangfire
            Configuration.BackgroundJobs.UseHangfire(configuration =>
            {
                configuration.GlobalConfiguration.UseMemoryStorage();
            });


        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

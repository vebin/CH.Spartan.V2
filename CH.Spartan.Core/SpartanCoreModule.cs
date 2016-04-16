using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using CH.Spartan.Authorization;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Infrastructure;

namespace CH.Spartan
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class SpartanCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;
            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SpartanConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "CH.Spartan.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<SpartanAuthorizationProvider>();
            Configuration.Settings.Providers.Add<SpartanSettingProvider>();


            DisableFilterIfHostInterceptorRegister.Initialize(IocManager);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

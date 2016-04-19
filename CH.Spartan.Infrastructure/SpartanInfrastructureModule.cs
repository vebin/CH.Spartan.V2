using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using CH.Spartan.Infrastructure;

namespace CH.Spartan
{

    public class SpartanInfrastructureModule : AbpModule
    {
        public override void PreInitialize()
        {
            DisableFilterIfHostInterceptorRegister.Initialize(IocManager);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

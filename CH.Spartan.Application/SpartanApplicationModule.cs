using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace CH.Spartan
{
    [DependsOn(typeof(SpartanCoreModule), typeof(AbpAutoMapperModule))]
    public class SpartanApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

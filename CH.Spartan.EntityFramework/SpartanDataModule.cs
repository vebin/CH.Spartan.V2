using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using CH.Spartan.EntityFramework;
using CH.Spartan.EntityFramework.Repositories;

namespace CH.Spartan
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SpartanCoreModule))]
    public class SpartanDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

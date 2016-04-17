using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Devices;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Editions;
using CH.Spartan.Users;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.MultiTenancy
{
    
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {

        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager)
            : base(

                tenantRepository,
                tenantFeatureRepository,
                editionManager
                )
        {
        }

        public async Task<IdentityResult> DeductMoneyByInstallDeviceAsync(Tenant tenant, Device device,DeviceType deviceType)
        {
            if (tenant.Balance < deviceType.ServiceCharge)
            {
                return AbpIdentityResult.Failed(L("余额不足"));
            }
            tenant.Balance -= deviceType.ServiceCharge;
            return IdentityResult.Success;
        }
    }
}
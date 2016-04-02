using Abp.Application.Features;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}
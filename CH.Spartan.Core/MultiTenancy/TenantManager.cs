using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Editions;
using CH.Spartan.Users;

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
    }
}
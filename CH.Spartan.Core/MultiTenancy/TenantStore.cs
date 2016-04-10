using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Roles;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using CH.Spartan.Repositories;

namespace CH.Spartan.MultiTenancy
{
    public class TenantStore : StoreBase<Tenant>
    {
        public TenantStore(
            IRepository<Tenant> tenantRepository, 
            IUnitOfWorkManager unitOfWorkManager) :
            base(tenantRepository, unitOfWorkManager)
        {
            
        }
    }
}

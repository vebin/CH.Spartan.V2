using Abp.Authorization.Roles;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}
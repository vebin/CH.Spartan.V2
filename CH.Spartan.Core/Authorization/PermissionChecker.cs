using Abp.Authorization;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

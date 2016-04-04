using Abp.MultiTenancy;
using Abp.Zero.Configuration;

namespace CH.Spartan.Authorization.Roles
{
    public static class AppRoleConfig
    {
        public static void Configure(IRoleManagementConfig roleManagementConfig)
        {
            //Static host roles

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    RoleNames.Host.Admin,
                    MultiTenancySides.Host)
                );

            //Static tenant roles

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    RoleNames.Tenants.Admin,
                    MultiTenancySides.Tenant)
                );
        }
    }
}

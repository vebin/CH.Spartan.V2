using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Entities;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        private readonly IPermissionManager _permissionManager;
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager)
        {
            _permissionManager = permissionManager;
        }

        public async Task<IdentityResult> CreateUserRoles(int tenantId)
        {
            var role = new Role()
            {
                Name = RoleNames.Tenants.User,
                DisplayName = RoleNames.Tenants.User,
                IsDefault = true,
                TenantId = tenantId
            };
            await CreateAsync(role);
            return IdentityResult.Success;
        }

        public async Task GrantAllUserPermissionsAsync(Role role)
        {
            var permissions =
                _permissionManager.GetAllPermissions(MultiTenancySides.Tenant).Where(p => !p.Name.IsIn(
                    PermissionNames.PlatformManages,
                    PermissionNames.PlatformManages_Device, 
                    PermissionNames.PlatformManages_User,
                    PermissionNames.PlatformManages_Role));
            await SetGrantedPermissionsAsync(role,permissions);
        }
    }
}
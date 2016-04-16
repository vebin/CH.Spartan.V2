using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.Users
{
    public class UserManager : AbpUserManager<Tenant, Role, User>
    {
        private readonly IRepository<User,long> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public UserManager(
            UserStore store,
            RoleManager roleManager,
            IRepository<Tenant> tenantRepository,
            IMultiTenancyConfig multiTenancyConfig,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository, IRepository<User, long> userRepository)
            : base(
                store,
                roleManager,
                tenantRepository,
                multiTenancyConfig,
                permissionManager,
                unitOfWorkManager,
                settingManager,
                userManagementConfig,
                iocResolver,
                cacheManager,
                organizationUnitRepository,
                userOrganizationUnitRepository,
                organizationUnitSettings,
                userLoginAttemptRepository)
        {
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<string> GetTenancyNameAsync(string userName)
        {
            var user = await Store.FindByNameAsync(userName);
            return user?.Tenant != null ? user.Tenant.TenancyName : "";
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _userRepository.DeleteAsync(id);
            }
        }

        public async Task<IdentityResult> CreateUserAsync(User user)
        {
            user.Name = user.UserName;
            user.Surname = user.UserName;
            user.Password = new Md532PasswordHasher().HashPassword(SpartanConsts.DefaultPassword);
            user.IsInitPassword = true;
            user.IsInitUserName = true;
            user.IsActive = true;
            user.IsEmailConfirmed = true;
            var result = await CreateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }

            await _unitOfWorkManager.Current.SaveChangesAsync();
            using (_unitOfWorkManager.Current.SetFilterParameter(AbpDataFilters.MayHaveTenant,AbpDataFilters.Parameters.TenantId, user.TenantId))
            {
                var roles = RoleManager.Roles.Where(p => p.IsDefault).ToList();
                foreach (var role in roles)
                {
                    result = await AddToRoleAsync(user.Id, role.Name);
                    if (!result.Succeeded)
                    {
                        return result;
                    }
                }
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
            return IdentityResult.Success;
        }
    }
}
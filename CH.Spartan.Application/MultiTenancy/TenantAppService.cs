using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Commons.Dto;
using CH.Spartan.Editions;
using CH.Spartan.MultiTenancy.Dto;
using CH.Spartan.Users;
using System.Linq.Dynamic;
using System.Data.Entity;
using Abp.Extensions;
using CH.Spartan.Commons.Linq;
using System;

namespace CH.Spartan.MultiTenancy
{
    public class TenantAppService : SpartanAppServiceBase, ITenantAppService
    {
        private readonly TenantManager _tenantManager;
        private readonly RoleManager _roleManager;
        private readonly EditionManager _editionManager;
        private readonly IRepository<Tenant> _tenantRepository; 
        public TenantAppService(TenantManager tenantManager, RoleManager roleManager, EditionManager editionManager, IRepository<Tenant> tenantRepository)
        {
            _tenantManager = tenantManager;
            _roleManager = roleManager;
            _editionManager = editionManager;
            _tenantRepository = tenantRepository;
        }

        public async Task<ListResultOutput<TenantListDto>> GetTenantList(GetTenantListInput input)
        {
            var list = await _tenantManager.Tenants
                .OrderBy(t => t.TenancyName)
                .ToListAsync();

            return new ListResultOutput<TenantListDto>(list.MapTo<List<TenantListDto>>());
        }

        public async Task<PagedResultOutput<TenantListDto>> GetTenantPaged(GetTenantPagedInput input)
        {
            var query = _tenantRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<TenantListDto>(count, list.MapTo<List<TenantListDto>>());
        }

        private async Task CreateTenant(EditTenantInput input)
        {
            
            //创建一个租户
            var tenant = new Tenant(input.Tenant.TenancyName, input.Tenant.Name) {IsActive = true};
            //设置当前租户 默认版本
            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            CheckErrors(await TenantManager.CreateAsync(tenant));
            await CurrentUnitOfWork.SaveChangesAsync(); //目的是为了获取新租户的 Id
            Role adminRole;
            Role userRole;
            //设置当前上下文 数据过滤 (所有的查询 都会加上TenantId= tenant.Id 这个条件)
            using (CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, tenant.Id))
            {
                //添加一个静态角色(Admin) 给租户
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync();

                //把所有的租户权限赋予这个角色
                adminRole = _roleManager.Roles.Single(r => r.Name == RoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                //创建一个该租户的用户角色 并且这个角色是默认用户创建的时候就添加的
                await _roleManager.CreateUserRoles(tenant.Id);
                //把所有的租户的用户的角色赋予该角色
                userRole = _roleManager.Roles.Single(r => r.Name == RoleNames.Tenants.User);
                await _roleManager.GrantAllUserPermissionsAsync(userRole);
            }

            //给这个租户 添加一个管理员用户
            User adminUser;
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                //取消租户过滤 目的 是为了让其添加用户的时候 检查用户名的唯一性 (不区分租户)
                adminUser = User.CreateTenantAdminUser(tenant.Id, input.Tenant.TenancyName, input.Tenant.EmailAddress, User.DefaultPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            //给新建的租户管理员 赋予 刚才创建的管理员角色
            CheckErrors(await UserManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        private async Task UpdateTenant(EditTenantInput input)
        {
            var tenant = await _tenantRepository.FirstOrDefaultAsync(input.Tenant.Id);
            input.Tenant.MapTo(tenant);
            await _tenantRepository.UpdateAsync(tenant);
        }

        public async Task EditTenant(EditTenantInput input)
        {
            if (input.Tenant.Id == 0)
            {
                await CreateTenant(input);
            }
            else
            {
                await UpdateTenant(input);
            }
        }

        public async Task<EditTenantOutput> FetchTenant(NullableIdInput input)
        {
            if (input.Id.HasValue)
            {
                return new EditTenantOutput((await _tenantRepository.FirstOrDefaultAsync(input.Id.Value)).MapTo<TenantDto>());
            }
            else
            {
                return new EditTenantOutput(new TenantDto());
            }
        }

        public async Task DeleteTenant(List<IdInput> input)
        {
           await _tenantRepository.DeleteAsync(p=>p.Id.IsIn(input.Select(o=>o.Id).ToArray()));
        }
    }
}
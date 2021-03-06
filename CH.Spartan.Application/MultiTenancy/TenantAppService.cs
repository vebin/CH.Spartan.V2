using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Editions;
using CH.Spartan.MultiTenancy.Dto;
using CH.Spartan.Users;
using Abp.Extensions;
using System.Data.Entity;
using CH.Spartan.Infrastructure;

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

        public async Task DeleteTenantAsync(List<IdInput> input)
        {
            foreach (var id in input)
            {
                await _tenantRepository.DeleteAsync(id.Id);
            }
        }

        public async Task<ListResultOutput<ComboboxItemDto>> GetTenantListAutoCompleteAsync(GetTenantListInput input)
        {
            var list = await _tenantRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();

            return
                new ListResultOutput<ComboboxItemDto>(
                    list.Select(p => new ComboboxItemDto {Value = p.Id.ToString(), DisplayText = p.Name}).ToList());
        }

        public async Task CreateTenantAsync(CreateTenantInput input)
        {
            var tenant = input.Tenant.MapTo<Tenant>();
            if (!tenant.EditionId.HasValue)
            {
                var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
                if (defaultEdition != null)
                {
                    tenant.EditionId = defaultEdition.Id;
                }
            }

            //添加租户
            CheckErrors(await TenantManager.CreateAsync(tenant));
            CurrentUnitOfWork.SaveChanges();
            using (CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId,tenant.Id))
            {
                //添加租户静态角色(管理员角色 普通用户角色)
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));
                await CurrentUnitOfWork.SaveChangesAsync();

                //把租户的部分权限赋予  管理员角色
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllAdminPermissionsAsync(adminRole);

                //把租户的部分权限赋予 普通用户角色
                var userRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.User);
                //设置新添加客户时默认添加的角色
                userRole.IsDefault = true;
                await _roleManager.GrantAllUserPermissionsAsync(userRole);
                //管理员账户
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.Tenant.TenancyName,input.Tenant.EmailAddress, SpartanConsts.DefaultPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync();
                
                //给管理员赋予管理员角色
                CheckErrors(await UserManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }

        }

        public async Task UpdateTenantAsync(UpdateTenantInput input)
        {
            var tenant = await _tenantRepository.GetAsync(input.Tenant.Id);
            input.Tenant.MapTo(tenant);
            await _tenantRepository.UpdateAsync(tenant);
        }

        public CreateTenantOutput GetNewTenant()
        {
            return new CreateTenantOutput(new CreateTenantDto());
        }

        public async Task<UpdateTenantOutput> GetUpdateTenantAsync(IdInput input)
        {
            var result = await _tenantRepository.GetAsync(input.Id);
            return new UpdateTenantOutput(result.MapTo<UpdateTenantDto>());
        }

        public async Task<GetTenantOutput> GetTenantAsync(IdInput input)
        {
            var result = await _tenantRepository.GetAsync(input.Id);
            return new GetTenantOutput(result.MapTo<GetTenantDto>());
        }

        public async Task<ListResultOutput<GetTenantListDto>> GetTenantListAsync(GetTenantListInput input)
        {
            var list = await _tenantRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();
            return new ListResultOutput<GetTenantListDto>(list.MapTo<List<GetTenantListDto>>());
        }

        public async Task<PagedResultOutput<GetTenantListDto>> GetTenantListPagedAsync(GetTenantListPagedInput input)
        {
            var query = _tenantRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetTenantListDto>(count, list.MapTo<List<GetTenantListDto>>());
        }
    }
}
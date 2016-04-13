using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Data.Entity;
using Abp.Authorization;
using Abp.Authorization.Interceptors;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Commons;
using CH.Spartan.Authorization.Roles.Dto;
using CH.Spartan.Roles.Dto;
using EntityFramework.Extensions;

namespace CH.Spartan.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : SpartanAppServiceBase,IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Role> _roleRepository; 
        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager, IRepository<Role> roleRepository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
        }

        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleRepository.GetAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task<ListResultOutput<GetRoleListDto>> GetRoleListAsync(GetRoleListInput input)
        {
            var list = await _roleRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetRoleListDto>(list.MapTo<List<GetRoleListDto>>());
        }

        public async Task<PagedResultOutput<GetRoleListDto>> GetRoleListPagedAsync(GetRoleListPagedInput input)
        {
            var query = _roleManager.Roles;
            //.WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetRoleListDto>(count, list.MapTo<List<GetRoleListDto>>());
        }

        public async Task CreateRoleAsync(CreateRoleInput input)
        {
            var role = input.Role.MapTo<Role>();
            await _roleManager.CreateAsync(role);
        }
    
        public async Task UpdateRoleAsync(UpdateRoleInput input)
        {
            var role = await _roleRepository.GetAsync(input.Role.Id);
            input.Role.MapTo(role);
            await _roleManager.UpdateAsync(role);
        }

        public CreateRoleOutput GetNewRole()
        {
            return new CreateRoleOutput(new CreateRoleDto());
        }

        public async Task<UpdateRoleOutput> GetUpdateRoleAsync(IdInput input)
        {
            var result = await _roleRepository.GetAsync(input.Id);
            return new UpdateRoleOutput(result.MapTo<UpdateRoleDto>());
        }

        public async Task DeleteRoleAsync(List<IdInput> input)
        {
            foreach (var id in input)
            {
                await _roleRepository.DeleteAsync(id.Id);
            }
        }
    }
}
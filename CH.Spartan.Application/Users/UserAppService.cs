using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Interceptors;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using CH.Spartan.Commons;
using CH.Spartan.Users.Dto;
using Abp.Extensions;
using Abp.UI;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.MultiTenancy;

namespace CH.Spartan.Users
{
    /* THIS IS JUST A SAMPLE. */
    public class UserAppService : SpartanAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Tenant> _tenantRepository;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager, IRepository<User, long> userRepository, IRepository<Tenant> tenantRepository)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<string> GetTenancyNameAsync(string userName)
        {
            UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant);
            return await _userManager.GetTenancyNameAsync(userName);
        }

        public async Task<ListResultOutput<GetUserListDto>> GetUserListAsync(GetUserListInput input)
        {
            var list = await _userRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetUserListDto>(list.MapTo<List<GetUserListDto>>());
        }

        [DisableFilterIfHost(AbpDataFilters.MayHaveTenant)]
        public async Task<PagedResultOutput<GetUserListDto>> GetUserListPagedAsync(GetUserListPagedInput input)
        {
            if (input.TenantId.HasValue)
            {
                CurrentUnitOfWork.EnableFilter(AbpDataFilters.MayHaveTenant);
                CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId,input.TenantId);
            }

            var query = _userRepository.GetAll()
                .Include(p => p.Tenant)
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.UserName.Contains(input.SearchText) ||
                         p.Name.Contains(input.SearchText))
                .WhereIf(input.IsActive.HasValue, p => p.IsActive == input.IsActive.Value)
                .WhereIfDynamic(input.StartTime.HasValue, input.SearchTime + ">", input.StartTime)
                .WhereIfDynamic(input.EndTime.HasValue, input.SearchTime + "<", input.EndTime);

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetUserListDto>(count, list.MapTo<List<GetUserListDto>>());
        }

        [DisableFilterIfHost(AbpDataFilters.MayHaveTenant)]
        public async Task CreateUserAsync(CreateUserInput input)
        {
            var user = input.User.MapTo<User>();
            CheckErrors(await _userManager.CreateUserAsync(user));
        }
        [DisableFilterIfHost(AbpDataFilters.MayHaveTenant)]
        public async Task UpdateUserAsync(UpdateUserInput input)
        {
            var user = await _userRepository.GetAsync(input.User.Id);
            input.User.MapTo(user);
            CheckErrors(await _userManager.UpdateAsync(user));
        }

        public CreateUserOutput GetNewUser()
        {
            var output = new CreateUserOutput(new CreateUserDto());
            if (!AbpSession.TenantId.HasValue)
            {
                //host
                output.Tenants = _tenantRepository.GetAllList().Select(
                    p => new ComboboxItemDto(p.Id.ToString(), p.TenancyName + "(" + p.Name + ")")).ToList();
            }

            return output;
        }

        [DisableFilterIfHost(AbpDataFilters.MayHaveTenant)]
        public async Task<UpdateUserOutput> GetUpdateUserAsync(IdInput input)
        {
            var result = await _userRepository.GetAsync(input.Id);
            return new UpdateUserOutput(result.MapTo<UpdateUserDto>());
        }

        [DisableFilterIfHost(AbpDataFilters.MayHaveTenant)]
        public async Task DeleteUserAsync(List<IdInput> input)
        {
            await _userManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
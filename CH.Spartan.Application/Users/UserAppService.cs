using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using CH.Spartan.Users.Dto;
using Abp.Extensions;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Infrastructure;

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

        public async Task<ListResultOutput<ComboboxItemDto>> GetUserListAutoCompleteAsync(GetUserListInput input)
        {
            var list = await _userRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();

            return
                new ListResultOutput<ComboboxItemDto>(
                    list.Select(p => new ComboboxItemDto { Value = p.Id.ToString(), DisplayText = p.Name }).ToList());
        }

        public async Task<ListResultOutput<GetUserListDto>> GetUserListAsync(GetUserListInput input)
        {
            var list = await _userRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.UserName.Contains(input.SearchText) ||
                         p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();
            return new ListResultOutput<GetUserListDto>(list.MapTo<List<GetUserListDto>>());
        }

        public async Task<PagedResultOutput<GetUserListDto>> GetUserListPagedAsync(GetUserListPagedInput input)
        {
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

        public async Task CreateUserAsync(CreateUserInput input)
        {
            var user = input.User.MapTo<User>();
            CheckErrors(await _userManager.CreateUserAsync(user));
        }
        public async Task UpdateUserAsync(UpdateUserInput input)
        {
            var user = await _userRepository.GetAsync(input.User.Id);
            input.User.MapTo(user);
            CheckErrors(await _userManager.UpdateAsync(user));
        }

        public CreateUserOutput GetNewUser()
        {
            var output = new CreateUserOutput(new CreateUserDto());
            return output;
        }

        public async Task<UpdateUserOutput> GetUpdateUserAsync(IdInput<long> input)
        {
            var result = await _userRepository.GetAsync(input.Id);
            return new UpdateUserOutput(result.MapTo<UpdateUserDto>());
        }

        public async Task DeleteUserAsync(List<IdInput<long>> input)
        {
            await _userManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
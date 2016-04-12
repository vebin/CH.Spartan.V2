using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Users.Dto;

namespace CH.Spartan.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<string> GetTenancyNameAsync(string userName);

        /// <summary>
        /// 获取 用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetUserListDto>> GetUserListAsync(GetUserListInput input);

        /// <summary>
        /// 获取 用户 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetUserListDto>> GetUserListPagedAsync(GetUserListPagedInput input);

        /// <summary>
        /// 添加 用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateUserAsync(CreateUserInput input);

        /// <summary>
        /// 更新 用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateUserAsync(UpdateUserInput input);

        /// <summary>
        /// 获取 新用户
        /// </summary>
        /// <returns></returns>
        CreateUserOutput GetNewUser();

        /// <summary>
        /// 获取 更新用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateUserOutput> GetUpdateUserAsync(IdInput input);

        /// <summary>
        /// 删除 用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteUserAsync(List<IdInput> input);

    }
}
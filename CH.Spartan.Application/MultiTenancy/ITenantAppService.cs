using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTenantOutput> GetTenantAsync(IdInput input);

        /// <summary>
        /// 获取 集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetTenantListDto>> GetTenantListAsync(GetTenantListInput input);

        /// <summary>
        /// 获取 集合 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetTenantListDto>> GetTenantListPagedAsync(GetTenantListPagedInput input);

        /// <summary>
        /// 获取 集合 自动补全
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<ComboboxItemDto>> GetTenantListAutoCompleteAsync(GetTenantListInput input);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateTenantAsync(CreateTenantInput input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateTenantAsync(UpdateTenantInput input);

        /// <summary>
        /// 获取 新对象
        /// </summary>
        /// <returns></returns>
        CreateTenantOutput GetNewTenant();

        /// <summary>
        /// 获取 更新对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateTenantOutput> GetUpdateTenantAsync(IdInput input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteTenantAsync(List<IdInput> input);
    }
}

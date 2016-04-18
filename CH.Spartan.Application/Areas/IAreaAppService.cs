using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Areas.Dto;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.Areas
{

    public interface IAreaAppService : IApplicationService
    {
	    /// <summary>
        /// 获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetAreaOutput> GetAreaAsync(IdInput input);

        /// <summary>
        /// 获取 区域
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetAreaListDto>> GetAreaListAsync(GetAreaListInput input);

        /// <summary>
        /// 获取 区域 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetAreaListDto>> GetAreaListPagedAsync(GetAreaListPagedInput input);

		/// <summary>
        /// 获取 集合 自动补全
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<ComboboxItemDto>> GetAreaListAutoCompleteAsync(GetAreaListInput input);

        /// <summary>
        /// 添加 区域
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateAreaAsync(CreateAreaInput input);

        /// <summary>
        /// 更新 区域
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAreaAsync(UpdateAreaInput input);

        /// <summary>
        /// 获取 新区域
        /// </summary>
        /// <returns></returns>
        CreateAreaOutput GetNewArea();

        /// <summary>
        /// 获取 更新区域
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateAreaOutput> GetUpdateAreaAsync(IdInput input);

        /// <summary>
        /// 删除 区域
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAreaAsync(List<IdInput> input);
    }
}

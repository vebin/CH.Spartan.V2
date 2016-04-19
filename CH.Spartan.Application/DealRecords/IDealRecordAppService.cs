using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.DealRecords.Dto;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DealRecords
{

    public interface IDealRecordAppService : IApplicationService
    {

        /// <summary>
        /// 获取 交易记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetDealRecordListDto>> GetDealRecordListAsync(GetDealRecordListInput input);

        /// <summary>
        /// 获取 交易记录 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetDealRecordListDto>> GetDealRecordListPagedAsync(GetDealRecordListPagedInput input);

		/// <summary>
        /// 获取 集合 自动补全
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<ComboboxItemDto>> GetDealRecordListAutoCompleteAsync(GetDealRecordListInput input);

        /// <summary>
        /// 删除 交易记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteDealRecordAsync(List<IdInput> input);
    }
}

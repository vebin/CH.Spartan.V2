using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.DeviceStocks.Dto;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks
{

    public interface IDeviceStockAppService : IApplicationService
    {
	    /// <summary>
        /// 获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDeviceStockOutput> GetDeviceStockAsync(IdInput input);

        /// <summary>
        /// 获取 库存管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetDeviceStockListDto>> GetDeviceStockListAsync(GetDeviceStockListInput input);

        /// <summary>
        /// 获取 库存管理 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetDeviceStockListDto>> GetDeviceStockListPagedAsync(GetDeviceStockListPagedInput input);

		/// <summary>
        /// 获取 集合 自动补全
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<ComboboxItemDto>> GetDeviceStockListAutoCompleteAsync(GetDeviceStockListInput input);

        /// <summary>
        /// 添加 库存管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateDeviceStockAsync(CreateDeviceStockInput input);

        /// <summary>
        /// 更新 库存管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateDeviceStockAsync(UpdateDeviceStockInput input);

        /// <summary>
        /// 获取 新库存管理
        /// </summary>
        /// <returns></returns>
        CreateDeviceStockOutput GetNewDeviceStock();

        /// <summary>
        /// 获取 更新库存管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateDeviceStockOutput> GetUpdateDeviceStockAsync(IdInput input);

        /// <summary>
        /// 删除 库存管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteDeviceStockAsync(List<IdInput> input);
    }
}

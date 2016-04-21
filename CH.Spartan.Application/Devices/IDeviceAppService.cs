using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Devices.Dto;

namespace CH.Spartan.Devices
{

    public interface IDeviceAppService : IApplicationService
    {
        #region 通用
        /// <summary>
        /// 获取 设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetDeviceListDto>> GetDeviceListAsync(GetDeviceListInput input);

        /// <summary>
        /// 获取 设备 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetDeviceListDto>> GetDeviceListPagedAsync(GetDeviceListPagedInput input);

        /// <summary>
        /// 删除 设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteDeviceAsync(List<IdInput> input);
        #endregion

        #region 代理
        /// <summary>
        /// 添加 设备 代理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateDeviceByAgentAsync(CreateDeviceByAgentInput input);

        /// <summary>
        /// 更新 设备 代理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateDeviceByAgentAsync(UpdateDeviceByAgentInput input);

        /// <summary>
        /// 获取 新设备 代理
        /// </summary>
        /// <returns></returns>
        CreateDeviceByAgentOutput GetNewDeviceByAgent();

        /// <summary>
        /// 获取 更新设备 代理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateDeviceByAgentOutput> GetUpdateDeviceByAgentAsync(IdInput input);
        #endregion

        #region 客户

        /// <summary>
        /// 添加 设备 客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateDeviceByCustomerAsync(CreateDeviceByCustomerInput input);

        /// <summary>
        /// 更新 设备 客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateDeviceByCustomerAsync(UpdateDeviceByCustomerInput input);

        /// <summary>
        /// 获取 新设备 客户
        /// </summary>
        /// <returns></returns>
        CreateDeviceByCustomerOutput GetNewDeviceByCustomer();

        /// <summary>
        /// 获取 更新设备 客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateDeviceByCustomerOutput> GetUpdateDeviceByCustomerAsync(IdInput input); 
        #endregion
    }
}

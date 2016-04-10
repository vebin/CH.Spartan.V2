using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Devices.Dto;

namespace CH.Spartan.Devices
{

    public interface IDeviceAppService : IApplicationService
    {
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
        /// 添加 设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateDeviceAsync(CreateDeviceInput input);

        /// <summary>
        /// 更新 设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateDeviceAsync(UpdateDeviceInput input);

        /// <summary>
        /// 获取 新设备
        /// </summary>
        /// <returns></returns>
        CreateDeviceOutput GetNewDevice();

        /// <summary>
        /// 获取 更新设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateDeviceOutput> GetUpdateDeviceAsync(IdInput input);

        /// <summary>
        /// 删除 设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteDeviceAsync(List<IdInput> input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.DeviceTypes.Dto;

namespace CH.Spartan.DeviceTypes
{

    public interface IDeviceTypeAppService : IApplicationService
    {
        /// <summary>
        /// 获取 设备类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetDeviceTypeListDto>> GetDeviceTypeListAsync(GetDeviceTypeListInput input);

        /// <summary>
        /// 获取 设备类型 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetDeviceTypeListDto>> GetDeviceTypeListPagedAsync(GetDeviceTypeListPagedInput input);


        /// <summary>
        /// 更新 设备类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateDeviceTypeAsync(UpdateDeviceTypeInput input);

        /// <summary>
        /// 获取 更新设备类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateDeviceTypeOutput> GetUpdateDeviceTypeAsync(IdInput input);
    }
}

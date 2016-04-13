using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Data.Entity;
using Abp.Authorization.Interceptors;
using CH.Spartan.Commons;
using CH.Spartan.Devices.Dto;
using EntityFramework.Extensions;

namespace CH.Spartan.Devices
{
    
    public class DeviceAppService : SpartanAppServiceBase, IDeviceAppService
    {
        private readonly DeviceManager _deviceManager;
        private readonly IRepository<Device> _deviceRepository;
        public DeviceAppService(IRepository<Device> deviceRepository,DeviceManager deviceManager)
        {
            _deviceRepository = deviceRepository;
            _deviceManager = deviceManager;
        }

        [DisableFilterIfHost]
        public async Task<ListResultOutput<GetDeviceListDto>> GetDeviceListAsync(GetDeviceListInput input)
        {
            var list = await _deviceRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceListDto>(list.MapTo<List<GetDeviceListDto>>());
        }

        [DisableFilterIfHost]
        public async Task<PagedResultOutput<GetDeviceListDto>> GetDeviceListPagedAsync(GetDeviceListPagedInput input)
        {
            var query = _deviceRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(), 
                p => p.BName.Contains(input.SearchText)||
                p.BLicensePlate.Contains(input.SearchText) ||
                p.BSimNo.Contains(input.SearchText) ||
                p.BNo.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceListDto>(count, list.MapTo<List<GetDeviceListDto>>());
        }

        [DisableFilterIfHost]
        public async Task CreateDeviceAsync(CreateDeviceInput input)
        {
            var device = input.Device.MapTo<Device>();
            await _deviceRepository.InsertAsync(device);
        }

        [DisableFilterIfHost]
        public async Task UpdateDeviceAsync(UpdateDeviceInput input)
        {
            var device = await _deviceRepository.GetAsync(input.Device.Id);
            input.Device.MapTo(device);
            await _deviceRepository.UpdateAsync(device);
        }
    
        public CreateDeviceOutput GetNewDevice()
        {
            return new CreateDeviceOutput(new CreateDeviceDto());
        }

        [DisableFilterIfHost]
        public async Task<UpdateDeviceOutput> GetUpdateDeviceAsync(IdInput input)
        {
            var result = await _deviceRepository.GetAsync(input.Id);
            return new UpdateDeviceOutput(result.MapTo<UpdateDeviceDto>());
        }

        [DisableFilterIfHost]
        public async Task DeleteDeviceAsync(List<IdInput> input)
        {
           await _deviceManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
        
    }
}
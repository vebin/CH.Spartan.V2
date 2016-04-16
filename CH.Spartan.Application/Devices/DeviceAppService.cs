using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Data.Entity;
using CH.Spartan.Devices.Dto;
using CH.Spartan.Infrastructure;

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

        public async Task<ListResultOutput<GetDeviceListDto>> GetDeviceListAsync(GetDeviceListInput input)
        {
            var list = await _deviceRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceListDto>(list.MapTo<List<GetDeviceListDto>>());
        }

        public async Task<PagedResultOutput<GetDeviceListDto>> GetDeviceListPagedAsync(GetDeviceListPagedInput input)
        {
            var query = _deviceRepository.GetAll()
                .Include(p=>p.Tenant)
                .Include(p=>p.User)
                .Include(p=>p.DeviceType)
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.BName.Contains(input.SearchText) ||
                         p.BLicensePlate.Contains(input.SearchText) ||
                         p.BSimNo.Contains(input.SearchText) ||
                         p.BNo.Contains(input.SearchText))
                .WhereIf(input.DeviceTypeId.HasValue, p => p.BDeviceTypeId == input.DeviceTypeId.Value)
                .WhereIf(input.IsLocated.HasValue, p => p.GIsLocated)
                .WhereIfDynamic(input.StartTime.HasValue, input.SearchTime + ">", input.StartTime)
                .WhereIfDynamic(input.EndTime.HasValue, input.SearchTime + "<", input.EndTime);

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceListDto>(count, list.MapTo<List<GetDeviceListDto>>());
        }

        public async Task CreateDeviceByAgentAsync(CreateDeviceByAgentInput input)
        {
            var device = input.Device.MapTo<Device>();
            await _deviceManager.CreateDeviceByAgentAsync(device);
        }

        public async Task UpdateDeviceByAgentAsync(UpdateDeviceByAgentInput input)
        {
            var device = await _deviceRepository.GetAsync(input.Device.Id);
            input.Device.MapTo(device);
            await _deviceRepository.UpdateAsync(device);
        }
    
        public CreateDeviceByAgentOutput GetNewDeviceByAgent()
        {
            return new CreateDeviceByAgentOutput(new CreateDeviceByAgentDto());
        }

        public async Task<UpdateDeviceByAgentOutput> GetUpdateDeviceByAgentAsync(IdInput input)
        {
            var result = await _deviceRepository.GetAsync(input.Id);
            return new UpdateDeviceByAgentOutput(result.MapTo<UpdateDeviceByAgentDto>());
        }

        public async Task DeleteDeviceAsync(List<IdInput> input)
        {
           await _deviceManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
        
    }
}
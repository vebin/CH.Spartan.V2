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
using CH.Spartan.Commons;
using CH.Spartan.Devices.Dto;

namespace CH.Spartan.Devices
{
	
    public class DeviceAppService : SpartanAppServiceBase, IDeviceAppService
    {
	    private readonly DeviceManager _deviceManager;
        public DeviceAppService(DeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }
	
        public async Task<ListResultOutput<GetDeviceListDto>> GetDeviceListAsync(GetDeviceListInput input)
        {
            var list = await _deviceManager.Store.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceListDto>(list.MapTo<List<GetDeviceListDto>>());
        }
		
        public async Task<PagedResultOutput<GetDeviceListDto>> GetDeviceListPagedAsync(GetDeviceListPagedInput input)
        {
            var query = _deviceManager.Store.GetAll();
                //.WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceListDto>(count, list.MapTo<List<GetDeviceListDto>>());
        }
	
        public async Task CreateDeviceAsync(CreateDeviceInput input)
        {
            var device = input.Device.MapTo<Device>();
            await _deviceManager.Store.CreateAsync(device);
        }
        
        public async Task UpdateDeviceAsync(UpdateDeviceInput input)
        {
            var device = await _deviceManager.Store.FindByIdAsync(input.Device.Id);
            input.Device.MapTo(device);
            await _deviceManager.Store.UpdateAsync(device);
        }
	
        public CreateDeviceOutput GetNewDevice()
        {
            return new CreateDeviceOutput(new CreateDeviceDto());
        }

		public async Task<UpdateDeviceOutput> GetUpdateDeviceAsync(IdInput input)
        {
            var result = await _deviceManager.Store.FindByIdAsync(input.Id);
            return new UpdateDeviceOutput(result.MapTo<UpdateDeviceDto>());
        }

        public async Task DeleteDeviceAsync(List<IdInput> input)
        {
           await _deviceManager.Store.DeleteByIdsAsync(input.Select(p=>p.Id));
        }
        
    }
}
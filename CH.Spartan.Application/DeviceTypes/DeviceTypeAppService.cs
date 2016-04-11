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
using CH.Spartan.DeviceTypes.Dto;
using EntityFramework.Extensions;

namespace CH.Spartan.DeviceTypes
{
    
    public class DeviceTypeAppService : SpartanAppServiceBase, IDeviceTypeAppService
    {
        private readonly DeviceTypeManager _deviceTypeManager;
        private readonly IRepository<DeviceType> _deviceTypeRepository; 
        public DeviceTypeAppService(DeviceTypeManager deviceTypeManager, IRepository<DeviceType> deviceTypeRepository)
        {
            _deviceTypeManager = deviceTypeManager;
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task<ListResultOutput<GetDeviceTypeListDto>> GetDeviceTypeListAsync(GetDeviceTypeListInput input)
        {
            var list = await _deviceTypeRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceTypeListDto>(list.MapTo<List<GetDeviceTypeListDto>>());
        }
        
        public async Task<PagedResultOutput<GetDeviceTypeListDto>> GetDeviceTypeListPagedAsync(GetDeviceTypeListPagedInput input)
        {
            var query = _deviceTypeRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.Name.Contains(input.SearchText) ||
                         p.SwitchInGateway.Contains(input.SearchText) ||
                         p.Supplier.Contains(input.SearchText) ||
                         p.Manufacturer.Contains(input.SearchText)
                );

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceTypeListDto>(count, list.MapTo<List<GetDeviceTypeListDto>>());
        }
        
        public async Task UpdateDeviceTypeAsync(UpdateDeviceTypeInput input)
        {
            var deviceType = await _deviceTypeRepository.GetAsync(input.DeviceType.Id);
            input.DeviceType.MapTo(deviceType);
            await _deviceTypeRepository.UpdateAsync(deviceType);
        }

        public async Task<UpdateDeviceTypeOutput> GetUpdateDeviceTypeAsync(IdInput input)
        {
            var result = await _deviceTypeRepository.GetAsync(input.Id);
            return new UpdateDeviceTypeOutput(result.MapTo<UpdateDeviceTypeDto>());
        }
        
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using System.Data.Entity;
using CH.Spartan.Commons;
using CH.Spartan.DeviceTypes.Dto;

namespace CH.Spartan.DeviceTypes
{

    public class DeviceTypeAppService : SpartanAppServiceBase, IDeviceTypeAppService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        public DeviceTypeAppService(IDeviceTypeRepository deviceTypeRepository)
        {
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
            var query = _deviceTypeRepository.GetAll();
            //.WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceTypeListDto>(count, list.MapTo<List<GetDeviceTypeListDto>>());
        }

        public async Task CreateDeviceTypeAsync(CreateDeviceTypeInput input)
        {
            var deviceType = input.DeviceType.MapTo<DeviceType>();
            await _deviceTypeRepository.InsertAsync(deviceType);
        }

        public async Task UpdateDeviceTypeAsync(UpdateDeviceTypeInput input)
        {
            var deviceType = await _deviceTypeRepository.FirstOrDefaultAsync(input.DeviceType.Id);
            input.DeviceType.MapTo(deviceType);
            await _deviceTypeRepository.UpdateAsync(deviceType);
        }

        public CreateDeviceTypeOutput GetNewDeviceType()
        {
            return new CreateDeviceTypeOutput(new CreateDeviceTypeDto());
        }

        public async Task<UpdateDeviceTypeOutput> GetUpdateDeviceTypeAsync(IdInput input)
        {
            var result = await _deviceTypeRepository.GetAsync(input.Id);
            return new UpdateDeviceTypeOutput(result.MapTo<UpdateDeviceTypeDto>());
        }

        public async Task DeleteDeviceTypeAsync(List<IdInput> input)
        {
            foreach (var item in input)
            {
                await _deviceTypeRepository.DeleteAsync(item.Id);
            }
        }

    }
}
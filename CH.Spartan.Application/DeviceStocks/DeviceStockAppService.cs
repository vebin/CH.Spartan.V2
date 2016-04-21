using System;
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
using CH.Spartan.DeviceStocks.Dto;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks
{
	
    public class DeviceStockAppService : SpartanAppServiceBase, IDeviceStockAppService
    {
	    private readonly DeviceStockManager _deviceStockManager;
	    private readonly IRepository<DeviceStock> _deviceStockRepository;
        public DeviceStockAppService(IRepository<DeviceStock> deviceStockRepository,DeviceStockManager deviceStockManager)
        {
		    _deviceStockRepository = deviceStockRepository;
            _deviceStockManager = deviceStockManager;
        }

		public async Task<GetDeviceStockOutput> GetDeviceStockAsync(IdInput input)
        {
            var result = await _deviceStockRepository.GetAsync(input.Id);
            return new GetDeviceStockOutput(result.MapTo<GetDeviceStockDto>());
        }

        public async Task<ListResultOutput<GetDeviceStockListDto>> GetDeviceStockListAsync(GetDeviceStockListInput input)
        {
            var list = await _deviceStockRepository.GetAll()
            	.WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.No.Contains(input.SearchText))
                .OrderBy(input)
				.Take(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceStockListDto>(list.MapTo<List<GetDeviceStockListDto>>());
        }

        public async Task<PagedResultOutput<GetDeviceStockListDto>> GetDeviceStockListPagedAsync(GetDeviceStockListPagedInput input)
        {
            var query = _deviceStockRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.No.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceStockListDto>(count, list.MapTo<List<GetDeviceStockListDto>>());
        }

        public async Task<ListResultOutput<ComboboxItemDto>> GetDeviceStockListAutoCompleteAsync(GetDeviceStockListInput input)
        {
            var list = await _deviceStockRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.No.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();

            return
                new ListResultOutput<ComboboxItemDto>(
                    list.Select(p => new ComboboxItemDto {Value = p.Id.ToString(), DisplayText = p.No }).ToList());
        }

        public async Task CreateDeviceStockAsync(CreateDeviceStockInput input)
        {
            var nos = input.DeviceStock.Nos.Split(Environment.NewLine);
            foreach (var no in nos)
            {
                await _deviceStockRepository.InsertAsync(new DeviceStock() {No = no.Trim()});
            }
        }
        public async Task UpdateDeviceStockAsync(UpdateDeviceStockInput input)
        {
            var deviceStock = await _deviceStockRepository.GetAsync(input.DeviceStock.Id);
            input.DeviceStock.MapTo(deviceStock);
            await _deviceStockRepository.UpdateAsync(deviceStock);
        }
	
        public CreateDeviceStockOutput GetNewDeviceStock()
        {
            return new CreateDeviceStockOutput(new CreateDeviceStockDto());
        }
        
		public async Task<UpdateDeviceStockOutput> GetUpdateDeviceStockAsync(IdInput input)
        {
            var result = await _deviceStockRepository.GetAsync(input.Id);
            return new UpdateDeviceStockOutput(result.MapTo<UpdateDeviceStockDto>());
        }

        public async Task DeleteDeviceStockAsync(List<IdInput> input)
        {
		   await _deviceStockManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
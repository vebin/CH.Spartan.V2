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
using CH.Spartan.DealRecords.Dto;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DealRecords
{
	
    public class DealRecordAppService : SpartanAppServiceBase, IDealRecordAppService
    {
	    private readonly DealRecordManager _dealRecordManager;
	    private readonly IRepository<DealRecord> _dealRecordRepository;
        public DealRecordAppService(IRepository<DealRecord> dealRecordRepository,DealRecordManager dealRecordManager)
        {
		    _dealRecordRepository = dealRecordRepository;
            _dealRecordManager = dealRecordManager;
        }

		

        public async Task<ListResultOutput<GetDealRecordListDto>> GetDealRecordListAsync(GetDealRecordListInput input)
        {
            var list = await _dealRecordRepository.GetAll()
            	.WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
				.Take(input)
                .ToListAsync();
            return new ListResultOutput<GetDealRecordListDto>(list.MapTo<List<GetDealRecordListDto>>());
        }

        [DisableFilterIfHost]
        public async Task<PagedResultOutput<GetDealRecordListDto>> GetDealRecordListPagedAsync(GetDealRecordListPagedInput input)
        {
            if (input.TenantId.HasValue)
            {
                CurrentUnitOfWork.EnableFilter(AbpDataFilters.MustHaveTenant);
                CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MustHaveTenant, AbpDataFilters.Parameters.TenantId,input.TenantId);
            }

            var query = _dealRecordRepository.GetAll()
                .Include(p=>p.Tenant)
                .WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.Name.Contains(input.SearchText)||p.No.Contains(input.SearchText)||p.OutNo.Contains(input.SearchText))
                .WhereIf(input.Type.HasValue,p=>p.Type==input.Type.Value)
                .WhereIfDynamic(input.StartTime.HasValue, input.SearchTime + ">", input.StartTime)
                .WhereIfDynamic(input.EndTime.HasValue, input.SearchTime + "<", input.EndTime);
            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDealRecordListDto>(count, list.MapTo<List<GetDealRecordListDto>>());
        }

        public async Task<ListResultOutput<ComboboxItemDto>> GetDealRecordListAutoCompleteAsync(GetDealRecordListInput input)
        {
            var list = await _dealRecordRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();

            return
                new ListResultOutput<ComboboxItemDto>(
                    list.Select(p => new ComboboxItemDto {Value = p.Id.ToString(), DisplayText = p.Name}).ToList());
        }

        public async Task DeleteDealRecordAsync(List<IdInput> input)
        {
		   await _dealRecordManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
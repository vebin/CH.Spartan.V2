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
using CH.Spartan.Areas.Dto;
using EntityFramework.Extensions;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.Areas
{
	
    public class AreaAppService : SpartanAppServiceBase, IAreaAppService
    {
	    private readonly AreaManager _areaManager;
	    private readonly IRepository<Area> _areaRepository;
        public AreaAppService(IRepository<Area> areaRepository,AreaManager areaManager)
        {
		    _areaRepository = areaRepository;
            _areaManager = areaManager;
        }

		public async Task<GetAreaOutput> GetAreaAsync(IdInput input)
        {
            var result = await _areaRepository.GetAsync(input.Id);
            return new GetAreaOutput(result.MapTo<GetAreaDto>());
        }

        public async Task<ListResultOutput<GetAreaListDto>> GetAreaListAsync(GetAreaListInput input)
        {
            var list = await _areaRepository.GetAll()
            	.WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
				.Take(input)
                .ToListAsync();
            return new ListResultOutput<GetAreaListDto>(list.MapTo<List<GetAreaListDto>>());
        }

        public async Task<PagedResultOutput<GetAreaListDto>> GetAreaListPagedAsync(GetAreaListPagedInput input)
        {
            var query = _areaRepository.GetAll();
                //.WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetAreaListDto>(count, list.MapTo<List<GetAreaListDto>>());
        }

        public async Task<ListResultOutput<ComboboxItemDto>> GetAreaListAutoCompleteAsync(GetAreaListInput input)
        {
            var list = await _areaRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),p => p.Name.Contains(input.SearchText))
                .OrderBy(input)
                .Take(input)
                .ToListAsync();

            return
                new ListResultOutput<ComboboxItemDto>(
                    list.Select(p => new ComboboxItemDto {Value = p.Id.ToString(), DisplayText = p.Name}).ToList());
        }

        public async Task CreateAreaAsync(CreateAreaInput input)
        {
            var area = input.Area.MapTo<Area>();
            await _areaRepository.InsertAsync(area);
        }
        public async Task UpdateAreaAsync(UpdateAreaInput input)
        {
            var area = await _areaRepository.GetAsync(input.Area.Id);
            input.Area.MapTo(area);
            await _areaRepository.UpdateAsync(area);
        }
	
        public CreateAreaOutput GetNewArea()
        {
            return new CreateAreaOutput(new CreateAreaDto());
        }
        
		public async Task<UpdateAreaOutput> GetUpdateAreaAsync(IdInput input)
        {
            var result = await _areaRepository.GetAsync(input.Id);
            return new UpdateAreaOutput(result.MapTo<UpdateAreaDto>());
        }

        public async Task DeleteAreaAsync(List<IdInput> input)
        {
		   await _areaManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
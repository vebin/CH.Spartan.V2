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
using Abp.Auditing;
using CH.Spartan.Commons;
using CH.Spartan.AuditLogs.Dto;
using EntityFramework.Extensions;

namespace CH.Spartan.AuditLogs
{
	
    public class AuditLogAppService : SpartanAppServiceBase, IAuditLogAppService
    {
	    private readonly AuditLogManager _AuditLogManager;
	    private readonly IRepository<AuditLog,long> _AuditLogRepository;
        public AuditLogAppService(IRepository<AuditLog,long> AuditLogRepository,AuditLogManager AuditLogManager)
        {
		    _AuditLogRepository = AuditLogRepository;
            _AuditLogManager = AuditLogManager;
        }
	
        public async Task<ListResultOutput<GetAuditLogListDto>> GetAuditLogListAsync(GetAuditLogListInput input)
        {
            var list = await _AuditLogRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetAuditLogListDto>(list.MapTo<List<GetAuditLogListDto>>());
        }
		
        public async Task<PagedResultOutput<GetAuditLogListDto>> GetAuditLogListPagedAsync(GetAuditLogListPagedInput input)
        {
            var query = _AuditLogRepository.GetAll()
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.BrowserInfo.Contains(input.SearchText) ||
                         p.ClientIpAddress.Contains(input.SearchText) ||
                         p.CustomData.Contains(input.SearchText) ||
                         p.ClientName.Contains(input.SearchText) ||
                         p.Exception.Contains(input.SearchText) ||
                         p.MethodName.Contains(input.SearchText) ||
                         p.ServiceName.Contains(input.SearchText)
                );

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetAuditLogListDto>(count, list.MapTo<List<GetAuditLogListDto>>());
        }

        public async Task DeleteAuditLogAsync(List<IdInput> input)
        {
		   await _AuditLogManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
    }
}
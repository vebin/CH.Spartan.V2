using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.AuditLogs.Dto;

namespace CH.Spartan.AuditLogs
{

    public interface IAuditLogAppService : IApplicationService
    {
        /// <summary>
        /// 获取 审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetAuditLogListDto>> GetAuditLogListAsync(GetAuditLogListInput input);

        /// <summary>
        /// 获取 审计日志 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetAuditLogListDto>> GetAuditLogListPagedAsync(GetAuditLogListPagedInput input);

        /// <summary>
        /// 删除 审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAuditLogAsync(List<IdInput> input);
    }
}

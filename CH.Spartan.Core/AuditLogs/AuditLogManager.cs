using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using CH.Spartan.Domain;

namespace CH.Spartan.AuditLogs
{
    public class AuditLogManager : ManagerBase
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;
        public AuditLogManager(
            IRepository<AuditLog, long> auditLogRepository,
            ISettingManager settingManager,
            ICacheManager cacheManager,
            IIocResolver iocResolver,
            IUnitOfWorkManager unitOfWorkManager)
            : base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _auditLogRepository.DeleteAsync(id);
            }
        }
    }
}
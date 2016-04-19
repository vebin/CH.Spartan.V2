using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using CH.Spartan.Domain;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.DealRecords
{
    public class DealRecordManager : ManagerBase
    {
        private readonly IRepository<DealRecord> _dealRecordRepository;
        public DealRecordManager(
            IRepository<DealRecord> dealRecordRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _dealRecordRepository=dealRecordRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _dealRecordRepository.DeleteAsync(id);
            }
        }
    }
}
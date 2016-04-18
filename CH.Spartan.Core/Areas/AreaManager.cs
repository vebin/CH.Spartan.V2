using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using CH.Spartan.Domain;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Areas
{
    public class AreaManager : ManagerBase
    {
        private readonly IRepository<Area> _areaRepository;
        public AreaManager(
            IRepository<Area> areaRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _areaRepository=areaRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _areaRepository.DeleteAsync(id);
            }
        }
    }
}
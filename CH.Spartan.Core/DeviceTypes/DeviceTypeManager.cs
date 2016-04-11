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

namespace CH.Spartan.DeviceTypes
{
    public class DeviceTypeManager : ManagerBase
    {
        private readonly IRepository<DeviceType> _deviceTypeRepository;

        public DeviceTypeManager(
            IRepository<DeviceType> deviceTypeRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _deviceTypeRepository.DeleteAsync(id);
            }
        }
    }
}
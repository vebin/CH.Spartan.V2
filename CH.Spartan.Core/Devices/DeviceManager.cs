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

namespace CH.Spartan.Devices
{
    public class DeviceManager : ManagerBase<Device>
    {
        private readonly IRepository<Device> _deviceRepository;
        public DeviceManager(
            IRepository<Device> deviceRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _deviceRepository.DeleteAsync(id);
            }
        }
    }
}
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
        public DeviceManager(
            IRepository<Device> deviceRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(deviceRepository, settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {

        }
    }
}
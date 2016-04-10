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
    public class DeviceTypeManager : ManagerBase<DeviceType>
    {
        public DeviceTypeManager(
            IRepository<DeviceType> _deviceTypeRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(_deviceTypeRepository, settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {

        }
    }
}
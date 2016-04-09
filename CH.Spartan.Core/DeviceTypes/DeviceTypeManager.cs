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

namespace CH.Spartan.DeviceTypes
{
    public class DeviceTypeManager : SpartanManagerBase<DeviceType>
    {
        public DeviceTypeManager(
            DeviceTypeStore deviceTypeStore, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(deviceTypeStore, settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {

        }
    }
}
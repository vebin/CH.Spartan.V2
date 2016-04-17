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
using Abp.UI;
using CH.Spartan.Devices;
using CH.Spartan.Domain;
using CH.Spartan.Infrastructure;

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

        public async Task<string> CreateCodeAsync(Device device,DeviceType deviceType)
        {
            if (deviceType == null)
            {
                throw new UserFriendlyException($"{L("不存在设备类型")}{device.BDeviceTypeId}");
            }

            switch (deviceType.CodeCreateRule)
            {
                case EnumCodeCreateRule.No:
                    return device.BNo; 
                case EnumCodeCreateRule.PrefixZeroAndNo:
                    return $"0{device.BNo}";
                default:
                    return device.BNo;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Runtime.Caching;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Domain;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Nodes;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.Devices
{
    public class DeviceManager : ManagerBase
    {
        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DeviceManager(
            IRepository<Device> deviceRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager, IRepository<Tenant> tenantRepository) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _deviceRepository = deviceRepository;
            _tenantRepository = tenantRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _deviceRepository.DeleteAsync(id);
            }
        }

        public async Task<IdentityResult> CreateAsync(Device device)
        {
            var result =await CheckDuplicateDeviceNoAsync(device.Id, device.BNo);
            if (!result.Succeeded)
            {
                return result;
            }

            await _deviceRepository.InsertAsync(device);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> CheckDuplicateDeviceNoAsync(int deviceId,string no)
        {
            //全范围内查找 不区分租户
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.MustHaveTenant))
            {
                var device = (await _deviceRepository.FirstOrDefaultAsync(p=>p.BNo==no));
                if (device != null && device.Id != deviceId)
                {
                    return AbpIdentityResult.Failed(string.Format(L("当前设备号已经被使用{0}"), no));
                }
                return IdentityResult.Success;
            }
        }

        public async Task<IdentityResult> UpdateAsync(Device device)
        {
            var result = await CheckDuplicateDeviceNoAsync(device.Id, device.BNo);
            if (!result.Succeeded)
            {
                return result;
            }

            await _deviceRepository.UpdateAsync(device);
            return IdentityResult.Success;
        }
    }
}
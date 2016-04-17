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
            await _deviceRepository.InsertAsync(device);
            return IdentityResult.Success;
        }
    }
}
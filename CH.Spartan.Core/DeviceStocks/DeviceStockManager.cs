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
using CH.Spartan.Domain;
using CH.Spartan.Infrastructure;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.DeviceStocks
{
    public class DeviceStockManager : ManagerBase
    {
        private readonly IRepository<DeviceStock> _deviceStockRepository;
        public DeviceStockManager(
            IRepository<DeviceStock> deviceStockRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _deviceStockRepository=deviceStockRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _deviceStockRepository.DeleteAsync(id);
            }
        }

        public async Task<IdentityResult> CheckIsHaveDeviceNoAsync(string no)
        {
            return await _deviceStockRepository.FirstOrDefaultAsync(p => p.No == no) == null
                ? AbpIdentityResult.Failed(L("所属租户库存没有当前设备号"))
                : IdentityResult.Success;
        }
    }
}
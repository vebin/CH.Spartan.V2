using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Runtime.Caching;
using Abp.UI;
using CH.Spartan.Devices;
using CH.Spartan.Domain;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Nodes
{
    public class NodeManager : ManagerBase
    {
        private readonly IRepository<Node> _nodeRepository;
        public NodeManager(
            IRepository<Node> nodeRepository, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _nodeRepository.DeleteAsync(id);
            }
        }

        public async Task<int> GetNodeIdAsync(Device  device)
        {
            var node =
                _nodeRepository.GetAll().Where(p => p.UsageCount < SpartanConsts.DefaultNodeMaxUsageCount).OrderByDescending(p=>p.UsageCount).FirstOrDefault();

            if (node == null)
            {
                throw new UserFriendlyException(L("已经没有足够的数据节点请联系管理员"));
            }
           
            node.UsageCount++;
            return node.Id;
        }
    }
}
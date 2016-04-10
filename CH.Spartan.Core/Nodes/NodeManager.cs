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

namespace CH.Spartan.Nodes
{
    public class NodeManager : ManagerBase<Node>
    {
        public NodeManager(
            NodeStore nodeStore, 
            ISettingManager settingManager, 
            ICacheManager cacheManager, 
            IIocResolver iocResolver, 
            IUnitOfWorkManager unitOfWorkManager) 
			: base(nodeStore, settingManager, cacheManager, iocResolver, unitOfWorkManager)
        {
        }
    }
}
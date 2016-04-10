using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using CH.Spartan.Repositories;

namespace CH.Spartan.Nodes
{
   public class NodeStore:StoreBase<Node>
   {
       public NodeStore(
           IRepository<Node> nodeRepository, 
           IUnitOfWorkManager unitOfWorkManager) 
            : base(nodeRepository, unitOfWorkManager)
       {

       }
    }
}
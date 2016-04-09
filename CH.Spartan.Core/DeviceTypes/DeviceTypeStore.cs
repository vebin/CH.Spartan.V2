using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using CH.Spartan.Repositories;

namespace CH.Spartan.DeviceTypes
{
   public class DeviceTypeStore: SpartanStoreBase<DeviceType>
   {
       public DeviceTypeStore(
           ISpartanRepositoryBase<DeviceType> deviceTypeRepository, 
           IUnitOfWorkManager unitOfWorkManager) 
            : base(deviceTypeRepository, unitOfWorkManager)
       {
           
       }
    }
}
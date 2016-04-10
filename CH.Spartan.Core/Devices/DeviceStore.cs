using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using CH.Spartan.Repositories;

namespace CH.Spartan.Devices
{
   public class DeviceStore:StoreBase<Device>
   {
       public DeviceStore(
           IRepository<Device> deviceRepository, 
           IUnitOfWorkManager unitOfWorkManager) 
            : base(deviceRepository, unitOfWorkManager)
       {

       }
    }
}
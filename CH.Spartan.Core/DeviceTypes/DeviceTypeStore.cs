using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Store;

namespace CH.Spartan.DeviceTypes
{
   public class DeviceTypeStore:AbpStore<DeviceType>
   {
       public DeviceTypeStore(
           IRepository<DeviceType> deviceTypeRepository, 
           IUnitOfWorkManager unitOfWorkManager) 
            : base(deviceTypeRepository, unitOfWorkManager)
       {

       }
    }
}
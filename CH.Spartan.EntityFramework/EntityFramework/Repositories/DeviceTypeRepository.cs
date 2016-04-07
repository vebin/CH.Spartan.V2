using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.EntityFramework;
using Abp.Domain.Repositories;
using Abp.Extensions;
using CH.Spartan.DeviceTypes;

namespace CH.Spartan.EntityFramework.Repositories
{
    public class DeviceTypeRepository : SpartanRepositoryBase<DeviceType>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IDbContextProvider<SpartanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

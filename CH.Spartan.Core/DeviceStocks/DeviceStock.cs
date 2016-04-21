using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.DeviceStocks
{
    public class DeviceStock : FullTenantEntity<Tenant>
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [Required, MaxLength(50)]
        public string No { get; set; }
    }
}

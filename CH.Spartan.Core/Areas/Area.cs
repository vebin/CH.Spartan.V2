using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.Areas
{
    public class Area : FullUserAndTenantEntity<User, Tenant>
    {
        /// <summary>
        /// 区域名字
        /// </summary>
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// 区域类型
        /// </summary>
        public EnumAreaType Type { get; set; }

        /// <summary>
        /// 区域点集合
        /// </summary>
        [MaxLength(500)]
        public string Points { get; set; }

        /// <summary>
        /// 区域半径
        /// </summary>
        public int? Radius { get; set; }
    }
}

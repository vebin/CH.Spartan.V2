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

namespace CH.Spartan.DealRecords
{
    public class DealRecord : FullUserAndTenantEntity<User,Tenant>
    {
        /// <summary>
        /// 交易名称
        /// </summary>
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        [MaxLength(250)]
        public string Remark { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public EnumDealRecordType Type { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CH.Spartan.Infrastructure
{
    /// <summary>
    /// This class can be used to simplify implementing .
    /// </summary>
    /// <typeparam name="TTenant">Type of the tenant</typeparam>
    public class FullTenantEntity<TTenant> : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// 所属租户Id
        /// </summary>
        public virtual int TenantId { get; set; }

        /// <summary>
        /// 所属租户
        /// </summary>
        [ForeignKey("TenantId")]
        public virtual TTenant Tenant { get; set; }
    }
}

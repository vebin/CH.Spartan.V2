using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Abp.Domain.Entities
{
    /// <summary>
    /// This class can be used to simplify implementing .
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public class FullUserEntity<TUser> : FullAuditedEntity, IMustHaveUser
    {
        /// <summary>
        /// 所属用户Id
        /// </summary>
        public virtual int UserId { get; set; }

        /// <summary>
        /// 所属租户
        /// </summary>
        [ForeignKey("UserId")]
        public virtual TUser User { get; set; }
    }
}

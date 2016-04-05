using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {
       
        public const int MaxPhoneLength = 64;

        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {

        }

        /// <summary>
        /// 余额
        /// </summary>
        public virtual decimal Balance { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required,MaxLength(MaxPhoneLength)]
        public virtual string Phone { get; set; }
    }
}
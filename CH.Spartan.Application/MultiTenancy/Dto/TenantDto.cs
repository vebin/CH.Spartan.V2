using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using CH.Spartan.Users;

namespace CH.Spartan.MultiTenancy.Dto
{
    [AutoMap(typeof (Tenant))]
    public class TenantDto : EntityDto, IDoubleWayDto
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}

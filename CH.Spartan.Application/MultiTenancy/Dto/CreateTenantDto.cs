using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Users;

namespace CH.Spartan.MultiTenancy.Dto
{
    [AutoMap(typeof(Tenant))]
    public class CreateTenantDto : IDoubleWayDto
    {

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public int? EditionId { get; set; }
    }

    public class CreateTenantInput : IInputDto
    {
        public CreateTenantDto Tenant { get; set; }
    }

    public class CreateTenantOutput : IOutputDto
    {
        public CreateTenantOutput(CreateTenantDto tenant)
        {
            Tenant = tenant;
        }

        public CreateTenantDto Tenant { get; set; }
    }
}

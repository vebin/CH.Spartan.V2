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
    public class UpdateTenantDto : EntityDto, IDoubleWayDto
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Tenant.MaxPhoneLength)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateTenantInput : IInputDto
    {
        public UpdateTenantDto Tenant { get; set; }
    }

    public class UpdateTenantOutput : IOutputDto
    {
        public UpdateTenantOutput(UpdateTenantDto tenant)
        {
            Tenant = tenant;
        }
        public UpdateTenantDto Tenant { get; set; }
    }
}

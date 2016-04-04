using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace CH.Spartan.MultiTenancy.Dto
{
    public class EditTenantOutput : IOutputDto
    {
        public EditTenantOutput(TenantDto tenant)
        {
            Tenant = tenant;
        }
        public TenantDto Tenant { get; set; }
    }
}

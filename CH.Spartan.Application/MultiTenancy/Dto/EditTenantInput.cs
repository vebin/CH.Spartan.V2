using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace CH.Spartan.MultiTenancy.Dto
{
    public class EditTenantInput : IInputDto
    {
        public TenantDto Tenant { get; set; }
    }
}

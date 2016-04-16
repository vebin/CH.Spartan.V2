using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.MultiTenancy.Dto
{
    [AutoMap(typeof (Tenant))]
    public class GetTenantDto : EntityDto, IOutputDto
    {
        public string Name { get; set; }

        public string TenancyName { get; set; }
    }

    public class GetTenantOutput : IOutputDto
    {
        public GetTenantOutput(GetTenantDto tenant)
        {
            Tenant = tenant;
        }

        public GetTenantDto Tenant { get; set; }
    }
}

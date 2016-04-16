using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class GetTenantListDto : AuditedEntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string IsActiveText { get; set; }
    }


    public class GetTenantListInput : QueryListResultRequestInput
    {

    }

    public class GetTenantListPagedInput : QueryListPagedResultRequestInput
    {

    }
}

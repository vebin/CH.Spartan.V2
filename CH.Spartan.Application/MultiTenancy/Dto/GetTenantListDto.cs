using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Commons;

namespace CH.Spartan.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class GetTenantListDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }


    public class GetTenantListInput : QueryListResultRequestInput
    {

    }

    public class GetTenantListPagedInput : QueryListPagedResultRequestInput
    {

    }
}

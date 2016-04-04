using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Commons.Dto;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        Task<ListResultOutput<TenantListDto>> GetTenantList(GetTenantListInput input);

        Task<PagedResultOutput<TenantListDto>> GetTenantPaged(GetTenantPagedInput input);

        Task EditTenant(EditTenantInput input);

        Task<EditTenantOutput> FetchTenant(NullableIdInput input);

        Task DeleteTenant(List<IdInput> input);
    }
}

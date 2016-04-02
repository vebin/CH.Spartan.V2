using System.Threading.Tasks;
using Abp.Application.Services;
using CH.Spartan.Roles.Dto;

namespace CH.Spartan.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}

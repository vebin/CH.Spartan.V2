using System.Threading.Tasks;
using Abp.Application.Services;
using CH.Spartan.Sessions.Dto;

namespace CH.Spartan.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

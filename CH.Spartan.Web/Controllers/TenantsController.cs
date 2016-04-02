using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.Authorization;
using CH.Spartan.MultiTenancy;

namespace CH.Spartan.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : SpartanControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}
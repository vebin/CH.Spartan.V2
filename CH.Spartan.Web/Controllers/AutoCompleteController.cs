using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;
using CH.Spartan.Users;
using CH.Spartan.Web.Models;

namespace CH.Spartan.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AutoCompleteController : SpartanControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ITenantAppService _tenantAppService;
        public AutoCompleteController(IUserAppService userAppService, ITenantAppService tenantAppService)
        {
            _userAppService = userAppService;
            _tenantAppService = tenantAppService;
        }
        public async Task<JsonResult> Tenant(GetTenantListInput input)
        {
            var result = await _tenantAppService.GetTenantListAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Mvc.Models;
using Abp.WebApi.Authorization;
using CH.Spartan.Authorization;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan.Web.Controllers
{


    [AbpMvcAuthorize]
    public class SystemManageController : SpartanControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public SystemManageController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        #region 租户

        #region 首页
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant)]
        public ActionResult Tenant()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant)]
        public async Task<JsonResult> SearchTenant(GetTenantListPagedInput input)
        {
            var result = await _tenantAppService.GetTenantListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant_Create)]
        public ActionResult CreateTenant()
        {
            var result = _tenantAppService.GetNewTenant();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant_Create)]
        public async Task<JsonResult> CreateTenant(CreateTenantInput input)
        {
            await _tenantAppService.CreateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant_Update)]
        public async Task<ActionResult> UpdateTenant(IdInput input)
        {
            var result = await _tenantAppService.GetUpdateTenantAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant_Update)]
        public async Task<JsonResult> UpdateTenant(UpdateTenantInput input)
        {
            await _tenantAppService.UpdateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(PermissionNames.SystemManages_Tenant_Delete)]
        public async Task<JsonResult> DeleteTenant(List<IdInput> input)
        {
            await _tenantAppService.DeleteTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
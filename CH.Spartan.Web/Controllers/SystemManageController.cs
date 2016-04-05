using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Mvc.Models;
using Abp.WebApi.Authorization;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan.Web.Controllers
{
    [AbpApiAuthorize]
    public class SystemManageController : SpartanControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public SystemManageController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        #region 租户

        #region 首页
        public ActionResult Tenant()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        public async Task<JsonResult> SearchTenant(GetTenantListPagedInput input)
        {
            var result = await _tenantAppService.GetTenantListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        public ActionResult CreateTenant()
        {
            var result = _tenantAppService.GetNewTenant();
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateTenant(CreateTenantInput input)
        {
            await _tenantAppService.CreateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        public ActionResult UpdateTenant(IdInput input)
        {
            var result = _tenantAppService.GetUpdateTenantAsync(input);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateTenant(UpdateTenantInput input)
        {
            await _tenantAppService.UpdateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        public async Task<JsonResult> DeleteTenant(List<IdInput> input)
        {
            await _tenantAppService.DeleteTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
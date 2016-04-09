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
using CH.Spartan.Devices;
using CH.Spartan.Devices.Dto;
using CH.Spartan.DeviceTypes;
using CH.Spartan.DeviceTypes.Dto;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan.Web.Controllers
{


    [AbpMvcAuthorize]
    public class SystemManageController : SpartanControllerBase
    {
        private readonly ITenantAppService _tenantAppService;
        private readonly IDeviceTypeAppService _deviceTypeAppService;
        private readonly IDeviceAppService _deviceAppService;
        public SystemManageController(
            ITenantAppService tenantAppService, 
            IDeviceTypeAppService deviceTypeAppService, 
            IDeviceAppService deviceAppService)
        {
            _tenantAppService = tenantAppService;
            _deviceTypeAppService = deviceTypeAppService;
            _deviceAppService = deviceAppService;
        }

        #region 租户

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant)]
        public ActionResult Tenant()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant)]
        public async Task<JsonResult> SearchTenant(GetTenantListPagedInput input)
        {
            var result = await _tenantAppService.GetTenantListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant_Create)]
        public ActionResult CreateTenant()
        {
            var result = _tenantAppService.GetNewTenant();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant_Create)]
        public async Task<JsonResult> CreateTenant(CreateTenantInput input)
        {
            await _tenantAppService.CreateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant_Update)]
        public async Task<ActionResult> UpdateTenant(IdInput input)
        {
            var result = await _tenantAppService.GetUpdateTenantAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant_Update)]
        public async Task<JsonResult> UpdateTenant(UpdateTenantInput input)
        {
            await _tenantAppService.UpdateTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Tenant_Delete)]
        public async Task<JsonResult> DeleteTenant(List<IdInput> input)
        {
            await _tenantAppService.DeleteTenantAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 设备类型

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType)]
        public ActionResult DeviceType()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType)]
        public async Task<JsonResult> SearchDeviceType(GetDeviceTypeListPagedInput input)
        {
            var result = await _deviceTypeAppService.GetDeviceTypeListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType_Create)]
        public ActionResult CreateDeviceType()
        {
            var result = _deviceTypeAppService.GetNewDeviceType();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType_Create)]
        public async Task<JsonResult> CreateDeviceType(CreateDeviceTypeInput input)
        {
            await _deviceTypeAppService.CreateDeviceTypeAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType_Update)]
        public async Task<ActionResult> UpdateDeviceType(IdInput input)
        {
            var result = await _deviceTypeAppService.GetUpdateDeviceTypeAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType_Update)]
        public async Task<JsonResult> UpdateDeviceType(UpdateDeviceTypeInput input)
        {
            await _deviceTypeAppService.UpdateDeviceTypeAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_DeviceType_Delete)]
        public async Task<JsonResult> DeleteDeviceType(List<IdInput> input)
        {
            await _deviceTypeAppService.DeleteDeviceTypeAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 设备

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device)]
        public ActionResult Device()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device)]
        public async Task<JsonResult> SearchDevice(GetDeviceListPagedInput input)
        {
            var result = await _deviceAppService.GetDeviceListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device_Create)]
        public ActionResult CreateDevice()
        {
            var result = _deviceAppService.GetNewDevice();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device_Create)]
        public async Task<JsonResult> CreateDevice(CreateDeviceInput input)
        {
            await _deviceAppService.CreateDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device_Update)]
        public async Task<ActionResult> UpdateDevice(IdInput input)
        {
            var result = await _deviceAppService.GetUpdateDeviceAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device_Update)]
        public async Task<JsonResult> UpdateDevice(UpdateDeviceInput input)
        {
            await _deviceAppService.UpdateDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_Device_Delete)]
        public async Task<JsonResult> DeleteDevice(List<IdInput> input)
        {
            await _deviceAppService.DeleteDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
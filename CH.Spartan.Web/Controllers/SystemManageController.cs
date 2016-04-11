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
using CH.Spartan.AuditLogs;
using CH.Spartan.AuditLogs.Dto;
using CH.Spartan.Authorization;
using CH.Spartan.Devices;
using CH.Spartan.DeviceTypes;
using CH.Spartan.DeviceTypes.Dto;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;
using CH.Spartan.Nodes;
using CH.Spartan.Nodes.Dto;

namespace CH.Spartan.Web.Controllers
{


    [AbpMvcAuthorize]
    public class SystemManageController : SpartanControllerBase
    {
        private readonly IAuditLogAppService _auditLogAppService;
        private readonly ITenantAppService _tenantAppService;
        private readonly IDeviceTypeAppService _deviceTypeAppService;
        private readonly INodeAppService _nodeAppService;
        public SystemManageController(
            ITenantAppService tenantAppService, 
            IDeviceTypeAppService deviceTypeAppService, 
            INodeAppService nodeAppService, 
            IAuditLogAppService auditLogAppService)
        {
            _tenantAppService = tenantAppService;
            _deviceTypeAppService = deviceTypeAppService;
            _nodeAppService = nodeAppService;
            _auditLogAppService = auditLogAppService;
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

        #endregion

        #region 节点

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node)]
        public ActionResult Node()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node)]
        public async Task<JsonResult> SearchNode(GetNodeListPagedInput input)
        {
            var result = await _nodeAppService.GetNodeListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node_Create)]
        public ActionResult CreateNode()
        {
            var result = _nodeAppService.GetNewNode();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node_Create)]
        public async Task<JsonResult> CreateNode(CreateNodeInput input)
        {
            await _nodeAppService.CreateNodeAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node_Update)]
        public async Task<ActionResult> UpdateNode(IdInput input)
        {
            var result = await _nodeAppService.GetUpdateNodeAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_Node_Update)]
        public async Task<JsonResult> UpdateNode(UpdateNodeInput input)
        {
            await _nodeAppService.UpdateNodeAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 审计日志

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_AuditLog)]
        public ActionResult AuditLog()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_AuditLog)]
        public async Task<JsonResult> SearchAuditLog(GetAuditLogListPagedInput input)
        {
            var result = await _auditLogAppService.GetAuditLogListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.SystemManages_AuditLog_Delete)]
        public async Task<JsonResult> DeleteAuditLog(List<IdInput> input)
        {
            await _auditLogAppService.DeleteAuditLogAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
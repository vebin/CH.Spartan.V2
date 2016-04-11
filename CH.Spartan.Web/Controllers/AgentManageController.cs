using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.Devices;
using CH.Spartan.Devices.Dto;

namespace CH.Spartan.Web.Controllers
{
    /// <summary>
    /// 代理商管理
    /// </summary>
    public class AgentManageController : SpartanControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;

        public AgentManageController(IDeviceAppService deviceAppService)
        {
            _deviceAppService = deviceAppService;
        }

        #region 设备

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device)]
        public ActionResult Device()
        {
            return View();
        }
        #endregion

        #region 搜索

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device)]
        public async Task<JsonResult> SearchDevice(GetDeviceListPagedInput input)
        {
            var result = await _deviceAppService.GetDeviceListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Create)]
        public ActionResult CreateDevice()
        {
            var result = _deviceAppService.GetNewDevice();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Create)]
        public async Task<JsonResult> CreateDevice(CreateDeviceInput input)
        {
            await _deviceAppService.CreateDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Update)]
        public async Task<ActionResult> UpdateDevice(IdInput input)
        {
            var result = await _deviceAppService.GetUpdateDeviceAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Update)]
        public async Task<JsonResult> UpdateDevice(UpdateDeviceInput input)
        {
            await _deviceAppService.UpdateDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Delete)]
        public async Task<JsonResult> DeleteDevice(List<IdInput> input)
        {
            await _deviceAppService.DeleteDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
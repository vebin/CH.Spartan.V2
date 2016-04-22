using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.Areas;
using CH.Spartan.Areas.Dto;
using CH.Spartan.Devices;
using CH.Spartan.Devices.Dto;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Web.Controllers
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [AbpMvcAuthorize]
    public class CustomerManageController : SpartanControllerBase
    {
        private readonly IAreaAppService _areaAppService;
        private readonly IDeviceAppService _deviceAppService;

        public CustomerManageController(IAreaAppService areaAppService, IDeviceAppService deviceAppService)
        {
            _areaAppService = areaAppService;
            _deviceAppService = deviceAppService;
        }

        #region 区域

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area)]
        public ActionResult Area()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area)]
        public async Task<JsonResult> GetAreaListPaged(GetAreaListPagedInput input)
        {
            var result = await _areaAppService.GetAreaListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area)]
        public async Task<JsonResult> GetAreaList(GetAreaListInput input)
        {
            var result = await _areaAppService.GetAreaListAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area_Create)]
        public ActionResult CreateArea()
        {
            var result = _areaAppService.GetNewArea();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area_Create)]
        public async Task<JsonResult> CreateArea(CreateAreaInput input)
        {
            await _areaAppService.CreateAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area_Update)]
        public async Task<ActionResult> UpdateArea(IdInput input)
        {
            var result = await _areaAppService.GetUpdateAreaAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area_Update)]
        public async Task<JsonResult> UpdateArea(UpdateAreaInput input)
        {
            await _areaAppService.UpdateAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Area_Delete)]
        public async Task<JsonResult> DeleteArea(List<IdInput> input)
        {
            await _areaAppService.DeleteAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 设备

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device)]
        public ActionResult Device()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device)]
        public async Task<JsonResult> GetDeviceListPaged(GetDeviceListPagedInput input)
        {
            input.UserId = AbpSession.GetUserId();
            var result = await _deviceAppService.GetDeviceListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device_Create)]
        public ActionResult CreateDevice()
        {
            var result = _deviceAppService.GetNewDeviceByCustomer();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device_Create)]
        public async Task<JsonResult> CreateDevice(CreateDeviceByCustomerInput input)
        {
            await _deviceAppService.CreateDeviceByCustomerAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device_Update)]
        public async Task<ActionResult> UpdateDevice(IdInput input)
        {
            var result = await _deviceAppService.GetUpdateDeviceByCustomerAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device_Update)]
        public async Task<JsonResult> UpdateDevice(UpdateDeviceByCustomerInput input)
        {
            await _deviceAppService.UpdateDeviceByCustomerAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.CustomerManages_Device_Delete)]
        public async Task<JsonResult> DeleteDevice(List<IdInput> input)
        {
            await _deviceAppService.DeleteDeviceAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
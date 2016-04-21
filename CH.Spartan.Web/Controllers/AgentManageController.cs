using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.DealRecords;
using CH.Spartan.DealRecords.Dto;
using CH.Spartan.Devices;
using CH.Spartan.Devices.Dto;
using CH.Spartan.DeviceStocks;
using CH.Spartan.DeviceStocks.Dto;
using CH.Spartan.Infrastructure;
using CH.Spartan.Users;
using CH.Spartan.Users.Dto;

namespace CH.Spartan.Web.Controllers
{
    /// <summary>
    /// 代理商管理
    /// </summary>
    [AbpMvcAuthorize]
    public class AgentManageController : SpartanControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;
        private readonly IUserAppService _userAppService;
        private readonly IDealRecordAppService _dealRecordAppService;
        private readonly IDeviceStockAppService _deviceStockAppService;
        public AgentManageController(IDeviceAppService deviceAppService, IUserAppService userAppService, IDealRecordAppService dealRecordAppService, IDeviceStockAppService deviceStockAppService)
        {
            _deviceAppService = deviceAppService;
            _userAppService = userAppService;
            _dealRecordAppService = dealRecordAppService;
            _deviceStockAppService = deviceStockAppService;
        }

        #region 设备

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device)]
        public ActionResult Device()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device)]
        public async Task<JsonResult> GetDeviceListPaged(GetDeviceListPagedInput input)
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
            var result = _deviceAppService.GetNewDeviceByAgent();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Create)]
        public async Task<JsonResult> CreateDevice(CreateDeviceByAgentInput input)
        {
            await _deviceAppService.CreateDeviceByAgentAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Update)]
        public async Task<ActionResult> UpdateDevice(IdInput input)
        {
            var result = await _deviceAppService.GetUpdateDeviceByAgentAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_Device_Update)]
        public async Task<JsonResult> UpdateDevice(UpdateDeviceByAgentInput input)
        {
            await _deviceAppService.UpdateDeviceByAgentAsync(input);
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

        #region 库存管理

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock)]
        public ActionResult DeviceStock()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock)]
        public async Task<JsonResult> GetDeviceStockListPaged(GetDeviceStockListPagedInput input)
        {
            var result = await _deviceStockAppService.GetDeviceStockListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock)]
        public async Task<JsonResult> GetDeviceStockList(GetDeviceStockListInput input)
        {
            var result = await _deviceStockAppService.GetDeviceStockListAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock_Create)]
        public ActionResult CreateDeviceStock()
        {
            var result = _deviceStockAppService.GetNewDeviceStock();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock_Create)]
        public async Task<JsonResult> CreateDeviceStock(CreateDeviceStockInput input)
        {
            _deviceStockAppService.CreateDeviceStockAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock_Update)]
        public async Task<ActionResult> UpdateDeviceStock(IdInput input)
        {
            var result = await _deviceStockAppService.GetUpdateDeviceStockAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock_Update)]
        public async Task<JsonResult> UpdateDeviceStock(UpdateDeviceStockInput input)
        {
            await _deviceStockAppService.UpdateDeviceStockAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DeviceStock_Delete)]
        public async Task<JsonResult> DeleteDeviceStock(List<IdInput> input)
        {
            await _deviceStockAppService.DeleteDeviceStockAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 用户

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User)]
        public new ActionResult User()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User)]
        public async Task<JsonResult> GetUserListPaged(GetUserListPagedInput input)
        {
            var result = await _userAppService.GetUserListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User_Create)]
        public ActionResult CreateUser()
        {
            var result = _userAppService.GetNewUser();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User_Create)]
        public async Task<JsonResult> CreateUser(CreateUserInput input)
        {
            await _userAppService.CreateUserAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User_Update)]
        public async Task<ActionResult> UpdateUser(IdInput<long> input)
        {
            var result = await _userAppService.GetUpdateUserAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User_Update)]
        public async Task<JsonResult> UpdateUser(UpdateUserInput input)
        {
            await _userAppService.UpdateUserAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_User_Delete)]
        public async Task<JsonResult> DeleteUser(List<IdInput<long>> input)
        {
            await _userAppService.DeleteUserAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion

        #region 交易记录

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DealRecord)]
        public ActionResult DealRecord()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DealRecord)]
        public async Task<JsonResult> GetDealRecordListPaged(GetDealRecordListPagedInput input)
        {
            var result = await _dealRecordAppService.GetDealRecordListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.AgentManages_DealRecord)]
        public async Task<JsonResult> GetDealRecordList(GetDealRecordListInput input)
        {
            var result = await _dealRecordAppService.GetDealRecordListAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_DealRecord_Delete)]
        public async Task<JsonResult> DeleteDealRecord(List<IdInput> input)
        {
            await _dealRecordAppService.DeleteDealRecordAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
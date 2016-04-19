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
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;
using CH.Spartan.Users.Dto;

namespace CH.Spartan.Web.Controllers
{
    /// <summary>
    /// 平台管理
    /// </summary>
    [AbpMvcAuthorize]
    public class PlatformManageController : SpartanControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;
        private readonly IUserAppService _userAppService;
        private readonly ITenantAppService _tenantAppService;
        private readonly IDealRecordAppService _dealRecordAppService;
        public PlatformManageController(IDeviceAppService deviceAppService, IUserAppService userAppService, ITenantAppService tenantAppService, IDealRecordAppService dealRecordAppService)
        {
            _deviceAppService = deviceAppService;
            _userAppService = userAppService;
            _tenantAppService = tenantAppService;
            _dealRecordAppService = dealRecordAppService;
        }

        #region 交易记录

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_DealRecord)]
        public ActionResult DealRecord()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_DealRecord)]
        public async Task<JsonResult> GetDealRecordListPaged(GetDealRecordListPagedInput input)
        {
            var result = await _dealRecordAppService.GetDealRecordListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.PlatformManages_DealRecord)]
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
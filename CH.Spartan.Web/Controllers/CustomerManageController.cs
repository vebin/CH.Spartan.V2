using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.Areas;
using CH.Spartan.Areas.Dto;
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

        public CustomerManageController(IAreaAppService areaAppService)
        {
            _areaAppService = areaAppService;
        }

        #region 区域

        #region 首页
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area)]
        public ActionResult Area()
        {
            return View();
        }
        #endregion

        #region 查询

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area)]
        public async Task<JsonResult> GetAreaListPaged(GetAreaListPagedInput input)
        {
            var result = await _areaAppService.GetAreaListPagedAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area)]
        public async Task<JsonResult> GetAreaList(GetAreaListInput input)
        {
            var result = await _areaAppService.GetAreaListAsync(input);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area_Create)]
        public ActionResult CreateArea()
        {
            var result = _areaAppService.GetNewArea();
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area_Create)]
        public async Task<JsonResult> CreateArea(CreateAreaInput input)
        {
            await _areaAppService.CreateAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新
        [HttpGet]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area_Update)]
        public async Task<ActionResult> UpdateArea(IdInput input)
        {
            var result = await _areaAppService.GetUpdateAreaAsync(input);
            return View(result);
        }

        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area_Update)]
        public async Task<JsonResult> UpdateArea(UpdateAreaInput input)
        {
            await _areaAppService.UpdateAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除
        [HttpPost]
        [AbpMvcAuthorize(SpartanPermissionNames.Customers_Setting_Area_Delete)]
        public async Task<JsonResult> DeleteArea(List<IdInput> input)
        {
            await _areaAppService.DeleteAreaAsync(input);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #endregion
    }
}
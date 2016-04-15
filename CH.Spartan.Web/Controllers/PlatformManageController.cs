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
        public PlatformManageController(IDeviceAppService deviceAppService, IUserAppService userAppService, ITenantAppService tenantAppService)
        {
            _deviceAppService = deviceAppService;
            _userAppService = userAppService;
            _tenantAppService = tenantAppService;
        }
    }
}
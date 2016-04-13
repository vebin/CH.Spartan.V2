using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Timing;
using Abp.Web.Mvc.Authorization;
using Abp.WebApi.Authorization;
using CH.Spartan.Web.Models;

namespace CH.Spartan.Web.Controllers
{
    [AbpMvcAuthorize()]
    public class LayoutController : SpartanControllerBase
    {
        [ChildActionOnly]
        public PartialViewResult DateTimeRange()
        {
            return PartialView("_DateTimeRange");
        }
    }
}
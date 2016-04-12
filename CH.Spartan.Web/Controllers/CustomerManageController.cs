using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CH.Spartan.Web.Controllers
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [AbpMvcAuthorize]
    public class CustomerManageController : SpartanControllerBase
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}
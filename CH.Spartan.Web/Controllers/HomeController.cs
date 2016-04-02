using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CH.Spartan.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SpartanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
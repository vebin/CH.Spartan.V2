using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CH.Spartan.Web.Controllers
{
    public class HomeController : SpartanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
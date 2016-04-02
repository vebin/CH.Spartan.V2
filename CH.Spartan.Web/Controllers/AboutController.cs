using System.Web.Mvc;

namespace CH.Spartan.Web.Controllers
{
    public class AboutController : SpartanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
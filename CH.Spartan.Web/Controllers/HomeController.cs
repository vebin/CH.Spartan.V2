using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Threading;
using Abp.Web.Mvc.Authorization;
using CH.Spartan.Sessions;
using CH.Spartan.Web.Models.Layout;

namespace CH.Spartan.Web.Controllers
{

    [AbpMvcAuthorize]
    public class HomeController : SpartanControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public HomeController(
            IUserNavigationManager userNavigationManager,
            ILocalizationManager localizationManager,
            ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }
        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId)),
                CurrentLanguage = _localizationManager.CurrentLanguage,
                Languages = _localizationManager.GetAllLanguages()
            };

            if (AbpSession.UserId.HasValue)
            {
                model.LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations());
            }
            return View(model);
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
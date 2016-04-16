using Abp.Web.Mvc.Views;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Web.Views
{
    public abstract class SpartanWebViewPageBase : SpartanWebViewPageBase<dynamic>
    {

    }

    public abstract class SpartanWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SpartanWebViewPageBase()
        {
            LocalizationSourceName = SpartanConsts.LocalizationSourceName;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Runtime.Session;
using CH.Spartan.Infrastructure;
using Hangfire.Dashboard;

namespace CH.Spartan.Authorization
{
    public class HangfireAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            var session = IocManager.Instance.Resolve<IAbpSession>();
            var permissionChecker = IocManager.Instance.Resolve<IPermissionChecker>();
            return session != null &&
                   permissionChecker.IsGranted(session.GetUserId(), SpartanPermissionNames.SystemManages_Job);
        }
    }
}

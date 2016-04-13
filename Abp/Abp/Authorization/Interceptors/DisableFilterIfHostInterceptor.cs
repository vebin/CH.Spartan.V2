using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Castle.DynamicProxy;

namespace Abp.Authorization.Interceptors
{

    [AttributeUsage(AttributeTargets.Method)]
    public class DisableFilterIfHostAttribute : Attribute
    {
        public string[] DisabledFilters { get; }

        public DisableFilterIfHostAttribute(string filterName=AbpDataFilters.MustHaveTenant)
        {
            DisabledFilters = new[] {filterName};
        }

        public DisableFilterIfHostAttribute(string[] filterNames)
        {
            DisabledFilters = filterNames;
        }

        internal static DisableFilterIfHostAttribute GetDisableFilterIfHostAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof (DisableFilterIfHostAttribute), false);
            if (attrs.Length > 0)
            {
                return (DisableFilterIfHostAttribute) attrs[0];
            }

            return null;
        }

        internal static bool HasDisableFilterIfHostAttribute(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof (DisableFilterIfHostAttribute), false);
            if (attrs.Length > 0)
            {
                return true;
            }

            return false;
        }
    }


    public class DisableFilterIfHostInterceptor : IInterceptor
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IAbpSession _abpSession;

        public DisableFilterIfHostInterceptor(IUnitOfWorkManager unitOfWorkManager, IAbpSession abpSession)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _abpSession = abpSession;
        }

        public void Intercept(IInvocation invocation)
        {
            var disableFilterIfHost =
                DisableFilterIfHostAttribute.GetDisableFilterIfHostAttributeOrNull(invocation.MethodInvocationTarget);
            if (disableFilterIfHost != null)
            {
                if (_unitOfWorkManager.Current != null &&
                    _abpSession != null &&
                    !_abpSession.TenantId.HasValue &&
                    disableFilterIfHost.DisabledFilters != null &&
                    disableFilterIfHost.DisabledFilters.Length > 0
                    )
                {
                    //for host
                    _unitOfWorkManager.Current.DisableFilter(disableFilterIfHost.DisabledFilters);

                }
            }
            invocation.Proceed();
        }
    }
}

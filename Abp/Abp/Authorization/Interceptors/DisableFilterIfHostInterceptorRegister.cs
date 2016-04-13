using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Uow;
using Castle.Core;
using Castle.MicroKernel;

namespace Abp.Authorization.Interceptors
{
   public class DisableFilterIfHostInterceptorRegister
    {
        /// <summary>
        /// Initializes the registerer.
        /// </summary>
        /// <param name="iocManager">IOC manager</param>
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += ComponentRegistered;
        }

        private static void ComponentRegistered(string key, IHandler handler)
        {
            if (handler.ComponentModel.Implementation.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any(DisableFilterIfHostAttribute.HasDisableFilterIfHostAttribute))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(DisableFilterIfHostInterceptor)));
            }
        }
    }
}

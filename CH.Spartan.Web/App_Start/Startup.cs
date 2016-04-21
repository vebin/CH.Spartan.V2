using System;
using System.Collections.Generic;
using System.Configuration;
using Abp.Owin;
using CH.Spartan.Api.Controllers;
using CH.Spartan.Authorization;
using CH.Spartan.Infrastructure;
using CH.Spartan.Web;
using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Twitter;
using Owin;
using Hangfire.Dashboard;

[assembly: OwinStartup(typeof(Startup))]

namespace CH.Spartan.Web
{
    

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
           
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
           
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();

            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                AuthorizationFilters = new[] { new HangfireAuthorizationFilter() }
            });
        }

        private static bool IsTrue(string appSettingName)
        {
            return string.Equals(
                ConfigurationManager.AppSettings[appSettingName],
                "true",
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
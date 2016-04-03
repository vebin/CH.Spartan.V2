using Abp.Application.Navigation;
using Abp.Localization;
using CH.Spartan.Authorization;

namespace CH.Spartan.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class SpartanNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "PageHome",
                        L("我的主页"),
                        url: "/",
                        icon: "fa fa-home"
                        )
                        .AddItem(new MenuItemDefinition("Monitor", L("定位监控"), "fa fa-map-signs"))
                        .AddItem(new MenuItemDefinition("HistoryTrack", L("历史轨迹"), "fa fa-reply"))
                        .AddItem(new MenuItemDefinition("Notification", L("报警信息"), "fa fa-bell"))
                        .AddItem(new MenuItemDefinition("MileageReport", L("里程统计"), "fa fa-bar-chart"))
                ).AddItem(
                    new MenuItemDefinition(
                        "MySetting",
                        L("我的设置"),
                        url: "/",
                        icon: "fa fa-tasks"
                        )
                        .AddItem(new MenuItemDefinition("DeviceSetting", L("车辆设置"), "fa fa-truck"))
                        .AddItem(new MenuItemDefinition("AreaSetting", L("区域设置"), "fa fa-flag-o"))
                ).AddItem(
                    new MenuItemDefinition(
                        "PlatformManage",
                        L("平台管理"),
                        url: "/",
                        icon: "fa fa-desktop"
                        )
                        .AddItem(new MenuItemDefinition("TenantManage", L("租户管理"), "fa fa-user-secret"))
                        .AddItem(new MenuItemDefinition("CustomerManage", L("客户管理"), "fa fa-user"))
                        .AddItem(new MenuItemDefinition("DeviceManage", L("车辆管理"), "fa fa-truck"))
                ).AddItem(
                    new MenuItemDefinition(
                        "SystemManage",
                        L("系统管理"),
                        url: "/",
                       icon: "fa fa-cog"
                        )
                        .AddItem(new MenuItemDefinition("UserManage", L("用户管理"), "fa fa-user"))
                        .AddItem(new MenuItemDefinition("RoleManage", L("角色管理"), "fa fa-check"))
                        .AddItem(new MenuItemDefinition("AuditLogs", L("审计日志"), "fa fa-calendar-o"))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

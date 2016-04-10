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
                        "Home",
                        L("我的主页"),
                        url: "#",
                        icon: "fa fa-home",
                        requiresAuthentication:true,
                        requiredPermissionName:SpartanPermissionNames.Homes
                        )
                        .AddItem(new MenuItemDefinition("Monitor", L("定位监控"), "fa fa-map-signs", "/Home/Monitor",true,SpartanPermissionNames.Homes_Monitor))
                        .AddItem(new MenuItemDefinition("HistoryTrack", L("历史轨迹"), "fa fa-reply", "/Home/HistoryTrack", true, SpartanPermissionNames.Homes_HistoryTrack))
                        .AddItem(new MenuItemDefinition("Notification", L("报警信息"), "fa fa-bell", "/Home/Notification", true, SpartanPermissionNames.Homes_Notification))
                        .AddItem(new MenuItemDefinition("MileageReport", L("里程统计"), "fa fa-bar-chart", "/Home/MileageReport", true, SpartanPermissionNames.Homes_MileageReport))
                ).AddItem(
                    new MenuItemDefinition(
                        "MySetting",
                        L("我的设置"),
                        url: "#",
                        icon: "fa fa-tasks",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.MySettings
                        )
                        .AddItem(new MenuItemDefinition("Device", L("车辆设置"), "fa fa-truck", "/MySetting/Device", true, SpartanPermissionNames.MySettings_Device))
                        .AddItem(new MenuItemDefinition("Area", L("区域设置"), "fa fa-flag-o", "/MySetting/Area", true, SpartanPermissionNames.MySettings_Area))
                ).AddItem(
                    new MenuItemDefinition(
                        "PlatformManage",
                        L("平台管理"),
                        url: "#",
                        icon: "fa fa-desktop",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.PlatformManages
                        )
                        .AddItem(new MenuItemDefinition("User", L("客户管理"), "fa fa-user", "/PlatformManage/User", true, SpartanPermissionNames.PlatformManages_User))
                        .AddItem(new MenuItemDefinition("Role", L("角色管理"), "fa fa-check", "/PlatformManage/Role", true, SpartanPermissionNames.PlatformManages_Role))
                        .AddItem(new MenuItemDefinition("Device", L("车辆管理"), "fa fa-truck", "/PlatformManage/Device", true, SpartanPermissionNames.PlatformManages_Device))
                        .AddItem(new MenuItemDefinition("DeviceStatistics", L("车辆统计"), "fa fa-truck", "/PlatformManage/DeviceStatistics", true, SpartanPermissionNames.PlatformManages_DeviceStatistics))
                        .AddItem(new MenuItemDefinition("UserStatistics", L("用户统计"), "fa fa-user", "/PlatformManage/UserStatistics", true, SpartanPermissionNames.PlatformManages_UserStatistics))
                        .AddItem(new MenuItemDefinition("DealRecord", L("交易记录"), "fa fa-credit-card", "/PlatformManage/DealRecord", true, SpartanPermissionNames.PlatformManages_DealRecord))
                ).AddItem(
                    new MenuItemDefinition(
                        "SystemManage",
                        L("系统管理"),
                        url: "#",
                        icon: "fa fa-cog",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.SystemManages
                        )
                        .AddItem(new MenuItemDefinition("Tenant", L("租户管理"), "fa fa-user-secret", "/SystemManage/Tenant", true, SpartanPermissionNames.SystemManages_Tenant))
                        .AddItem(new MenuItemDefinition("DeviceType", L("设备类型"), "fa fa-square-o", "/SystemManage/DeviceType", true, SpartanPermissionNames.SystemManages_Tenant))
                        .AddItem(new MenuItemDefinition("Node", L("数据节点"), "fa fa-database", "/SystemManage/Node", true, SpartanPermissionNames.SystemManages_Node))
                        .AddItem(new MenuItemDefinition("AuditLog", L("审计日志"), "fa fa-calendar-o", "/SystemManage/AuditLog", true, SpartanPermissionNames.SystemManages_AuditLog))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

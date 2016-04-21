using Abp.Application.Navigation;
using Abp.Localization;

namespace CH.Spartan.Infrastructure
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
                        "Customers",
                        L("我的主页"),
                        url: "#",
                        icon: "fa fa-home",
                        requiresAuthentication:true,
                        requiredPermissionName:SpartanPermissionNames.Customers
                        )
                        .AddItem(new MenuItemDefinition("Monitor", L("定位监控"), "fa fa-map-signs", "/CustomerManage/Monitor", true,SpartanPermissionNames.Customers_Monitor))
                        .AddItem(new MenuItemDefinition("HistoryTrack", L("历史轨迹"), "fa fa-reply", "/CustomerManage/HistoryTrack", true, SpartanPermissionNames.Customers_HistoryTrack))
                        .AddItem(new MenuItemDefinition("Notification", L("报警信息"), "fa fa-bell", "/CustomerManage/Notification", true, SpartanPermissionNames.Customers_Notification))
                        .AddItem(new MenuItemDefinition("MileageReport", L("里程统计"), "fa fa-bar-chart", "/CustomerManage/MileageReport", true, SpartanPermissionNames.Customers_MileageReport))
                ).AddItem(
                    new MenuItemDefinition(
                        "Customers_Setting",
                        L("我的设置"),
                        url: "#",
                        icon: "fa fa-tasks",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.Customers_Setting
                        )
                        .AddItem(new MenuItemDefinition("Device", L("车辆设置"), "fa fa-truck", "/CustomerManage/Device", true, SpartanPermissionNames.Customers_Setting_Device))
                        .AddItem(new MenuItemDefinition("Area", L("区域设置"), "fa fa-flag-o", "/CustomerManage/Area", true, SpartanPermissionNames.Customers_Setting_Area))
                ).AddItem(
                    new MenuItemDefinition(
                        "AgentManage",
                        L("代理管理"),
                        url: "#",
                        icon: "fa fa-desktop",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.AgentManages
                        )
                        .AddItem(new MenuItemDefinition("User", L("客户管理"), "fa fa-user", "/AgentManage/User", true, SpartanPermissionNames.AgentManages_User))
                        //.AddItem(new MenuItemDefinition("Role", L("角色管理"), "fa fa-check", "/AgentManage/Role", true, SpartanPermissionNames.AgentManages_Role))
                        .AddItem(new MenuItemDefinition("Device", L("车辆管理"), "fa fa-truck", "/AgentManage/Device", true, SpartanPermissionNames.AgentManages_Device))
                        .AddItem(new MenuItemDefinition("DeviceStock", L("库存管理"), "fa fa-hourglass-half", "/AgentManage/DeviceStock", true, SpartanPermissionNames.AgentManages_DeviceStock))
                        .AddItem(new MenuItemDefinition("DealRecord", L("交易记录"), "fa fa-credit-card", "/AgentManage/DealRecord", true, SpartanPermissionNames.AgentManages_DealRecord))
                )
                .AddItem(
                    new MenuItemDefinition(
                        "PlatformManage",
                        L("平台管理"),
                        url: "#",
                        icon: "fa fa-desktop",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.PlatformManages
                        )
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
                        .AddItem(new MenuItemDefinition("Job", L("调度任务"), "fa fa-tasks", "/Jobs", true, SpartanPermissionNames.SystemManages_Job))
                        .AddItem(new MenuItemDefinition("AuditLog", L("审计日志"), "fa fa-calendar-o", "/SystemManage/AuditLog", true, SpartanPermissionNames.SystemManages_AuditLog))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

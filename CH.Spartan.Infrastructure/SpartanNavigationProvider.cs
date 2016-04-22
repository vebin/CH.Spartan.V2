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
                        L("我的主页"),//客户主页
                        url: "#",
                        icon: "fa fa-home",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.CustomerManages
                        )
                        .AddItem(new MenuItemDefinition("Monitor", L("定位监控"), "fa fa-map-signs", "/CustomerManage/Monitor", true, SpartanPermissionNames.CustomerManages_Monitor))
                        .AddItem(new MenuItemDefinition("HistoryTrack", L("历史轨迹"), "fa fa-reply", "/CustomerManage/HistoryTrack", true, SpartanPermissionNames.CustomerManages_HistoryTrack))
                        .AddItem(new MenuItemDefinition("Notification", L("报警信息"), "fa fa-bell", "/CustomerManage/Notification", true, SpartanPermissionNames.CustomerManages_Notification))
                        .AddItem(new MenuItemDefinition("MileageReport", L("里程统计"), "fa fa-bar-chart", "/CustomerManage/MileageReport", true, SpartanPermissionNames.CustomerManages_MileageReport))
                ).AddItem(
                    new MenuItemDefinition(
                        "CustomersManage",
                        L("我的设置"),
                        url: "#",
                        icon: "fa fa-tasks",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.CustomerManages
                        )
                        .AddItem(new MenuItemDefinition("Device", L("车辆管理"), "fa fa-truck", "/CustomerManage/Device", true, SpartanPermissionNames.CustomerManages_Device))
                        .AddItem(new MenuItemDefinition("Area", L("区域管理"), "fa fa-flag-o", "/CustomerManage/Area", true, SpartanPermissionNames.CustomerManages_Area))
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Agents",
                        L("客户主页"),//代理客户的主页
                        url: "#",
                        icon: "fa fa-circle-o-notch",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.AgentManages
                        )
                        .AddItem(new MenuItemDefinition("Monitor", L("定位监控"), "fa fa-map-signs", "/AgentManage/Monitor", true, SpartanPermissionNames.AgentManages_Monitor))
                        .AddItem(new MenuItemDefinition("HistoryTrack", L("历史轨迹"), "fa fa-reply", "/AgentManage/HistoryTrack", true, SpartanPermissionNames.AgentManages_HistoryTrack))
                        .AddItem(new MenuItemDefinition("Notification", L("报警信息"), "fa fa-bell", "/AgentManage/Notification", true, SpartanPermissionNames.AgentManages_Notification))
                        .AddItem(new MenuItemDefinition("MileageReport", L("里程统计"), "fa fa-bar-chart", "/AgentManage/MileageReport", true, SpartanPermissionNames.AgentManages_MileageReport))
                )
                .AddItem(
                    new MenuItemDefinition(
                        "AgentManage",
                        L("代理管理"),
                        url: "#",
                        icon: "fa fa-desktop",
                        requiresAuthentication: true,
                        requiredPermissionName: SpartanPermissionNames.AgentManages
                        )
                        .AddItem(new MenuItemDefinition("User", L("客户管理"), "fa fa-user", "/AgentManage/User", true, SpartanPermissionNames.AgentManages_User))
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
                        .AddItem(new MenuItemDefinition("AuditLog", L("审计日志"), "fa fa-calendar-o", "/SystemManage/AuditLog", true, SpartanPermissionNames.SystemManages_AuditLog))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

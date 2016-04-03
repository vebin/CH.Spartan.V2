using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CH.Spartan.Authorization
{
    public class SpartanAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var homes = context.GetPermissionOrNull(PermissionNames.Homes);
            if (homes == null)
            {
                homes = context.CreatePermission(PermissionNames.Homes, L("我的主页"), multiTenancySides: MultiTenancySides.Tenant);
            }
            homes.CreateChildPermission(PermissionNames.Homes_Monitor, L("定位监控"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(PermissionNames.Homes_HistoryTrack, L("历史轨迹"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(PermissionNames.Homes_Notification, L("报警信息"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(PermissionNames.Homes_MileageReport, L("里程统计"), multiTenancySides: MultiTenancySides.Tenant);

            var mySettings = context.GetPermissionOrNull(PermissionNames.MySettings);
            if (mySettings == null)
            {
                mySettings = context.CreatePermission(PermissionNames.MySettings, L("我的设置"), multiTenancySides: MultiTenancySides.Tenant);
            }

            mySettings.CreateChildPermission(PermissionNames.MySettings_Device, L("车辆设置"), multiTenancySides: MultiTenancySides.Tenant);
            mySettings.CreateChildPermission(PermissionNames.MySettings_Area, L("区域设置"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManages = context.GetPermissionOrNull(PermissionNames.PlatformManages);
            if (platformManages == null)
            {
                platformManages = context.CreatePermission(PermissionNames.PlatformManages, L("平台管理"), multiTenancySides: MultiTenancySides.Tenant);
            }

            platformManages.CreateChildPermission(PermissionNames.PlatformManages_User, L("客户管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManages.CreateChildPermission(PermissionNames.PlatformManages_Role, L("角色管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManages.CreateChildPermission(PermissionNames.PlatformManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Tenant);

            var systemManages = context.GetPermissionOrNull(PermissionNames.SystemManages);
            if (systemManages == null)
            {
                systemManages = context.CreatePermission(PermissionNames.SystemManages, L("系统管理"), multiTenancySides: MultiTenancySides.Host);
            }

            systemManages.CreateChildPermission(PermissionNames.SystemManages_Tenant, L("租户管理"), multiTenancySides: MultiTenancySides.Host);
            systemManages.CreateChildPermission(PermissionNames.SystemManages_AuditLog, L("审计日志"), multiTenancySides: MultiTenancySides.Host);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

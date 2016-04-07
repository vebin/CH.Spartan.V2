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

            var mySettingDevice =  mySettings.CreateChildPermission(PermissionNames.MySettings_Device, L("车辆设置"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(PermissionNames.MySettings_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(PermissionNames.MySettings_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(PermissionNames.MySettings_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var mySettingArea= mySettings.CreateChildPermission(PermissionNames.MySettings_Area, L("区域设置"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(PermissionNames.MySettings_Area_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(PermissionNames.MySettings_Area_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(PermissionNames.MySettings_Area_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);






            var platformManages = context.GetPermissionOrNull(PermissionNames.PlatformManages);
            if (platformManages == null)
            {
                platformManages = context.CreatePermission(PermissionNames.PlatformManages, L("平台管理"));
            }

            var platformManageUser=  platformManages.CreateChildPermission(PermissionNames.PlatformManages_User, L("客户管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(PermissionNames.PlatformManages_User_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(PermissionNames.PlatformManages_User_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(PermissionNames.PlatformManages_User_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManageRole = platformManages.CreateChildPermission(PermissionNames.PlatformManages_Role, L("角色管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(PermissionNames.PlatformManages_Role_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(PermissionNames.PlatformManages_Role_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(PermissionNames.PlatformManages_Role_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManageDevice = platformManages.CreateChildPermission(PermissionNames.PlatformManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(PermissionNames.PlatformManages_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(PermissionNames.PlatformManages_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(PermissionNames.PlatformManages_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManageDeviceStatistics = platformManages.CreateChildPermission(PermissionNames.PlatformManages_DeviceStatistics, L("车辆统计"), multiTenancySides: MultiTenancySides.Host);
            var platformManageUserStatistics = platformManages.CreateChildPermission(PermissionNames.PlatformManages_UserStatistics, L("用户统计"), multiTenancySides: MultiTenancySides.Host);

            var platformManageDealRecord = platformManages.CreateChildPermission(PermissionNames.PlatformManages_DealRecord, L("交易记录"), multiTenancySides: MultiTenancySides.Host);
            platformManageDealRecord.CreateChildPermission(PermissionNames.PlatformManages_DealRecord_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);



            var systemManage = context.GetPermissionOrNull(PermissionNames.SystemManages);
            if (systemManage == null)
            {
                systemManage = context.CreatePermission(PermissionNames.SystemManages, L("系统管理"), multiTenancySides: MultiTenancySides.Host);
            }

            var systemManagesTenant = systemManage.CreateChildPermission(PermissionNames.SystemManages_Tenant, L("租户管理"), multiTenancySides: MultiTenancySides.Host);
            systemManagesTenant.CreateChildPermission(PermissionNames.SystemManages_Tenant_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            systemManagesTenant.CreateChildPermission(PermissionNames.SystemManages_Tenant_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);
            systemManagesTenant.CreateChildPermission(PermissionNames.SystemManages_Tenant_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);
            systemManagesTenant.CreateChildPermission(PermissionNames.SystemManages_Tenant_Deposit, L("充值"), multiTenancySides: MultiTenancySides.Host);

            var systemManageDeviceType = systemManage.CreateChildPermission(PermissionNames.SystemManages_DeviceType, L("设备类型"), multiTenancySides: MultiTenancySides.Host);
            systemManageDeviceType.CreateChildPermission(PermissionNames.SystemManages_DeviceType_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            systemManageDeviceType.CreateChildPermission(PermissionNames.SystemManages_DeviceType_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);
            systemManageDeviceType.CreateChildPermission(PermissionNames.SystemManages_DeviceType_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);

            var systemManageAuditLog = systemManage.CreateChildPermission(PermissionNames.SystemManages_AuditLog, L("审计日志"), multiTenancySides: MultiTenancySides.Host);
            systemManageAuditLog.CreateChildPermission(PermissionNames.SystemManages_AuditLog_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CH.Spartan
{
    public class SpartanAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var homes = context.GetPermissionOrNull(SpartanPermissionNames.Homes);
            if (homes == null)
            {
                homes = context.CreatePermission(SpartanPermissionNames.Homes, L("我的主页"), multiTenancySides: MultiTenancySides.Tenant);
            }
            homes.CreateChildPermission(SpartanPermissionNames.Homes_Monitor, L("定位监控"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(SpartanPermissionNames.Homes_HistoryTrack, L("历史轨迹"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(SpartanPermissionNames.Homes_Notification, L("报警信息"), multiTenancySides: MultiTenancySides.Tenant);
            homes.CreateChildPermission(SpartanPermissionNames.Homes_MileageReport, L("里程统计"), multiTenancySides: MultiTenancySides.Tenant);

            var mySettings = context.GetPermissionOrNull(SpartanPermissionNames.MySettings);
            if (mySettings == null)
            {
                mySettings = context.CreatePermission(SpartanPermissionNames.MySettings, L("我的设置"), multiTenancySides: MultiTenancySides.Tenant);
            }

            var mySettingDevice =  mySettings.CreateChildPermission(SpartanPermissionNames.MySettings_Device, L("车辆设置"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(SpartanPermissionNames.MySettings_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(SpartanPermissionNames.MySettings_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingDevice.CreateChildPermission(SpartanPermissionNames.MySettings_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var mySettingArea= mySettings.CreateChildPermission(SpartanPermissionNames.MySettings_Area, L("区域设置"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(SpartanPermissionNames.MySettings_Area_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(SpartanPermissionNames.MySettings_Area_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            mySettingArea.CreateChildPermission(SpartanPermissionNames.MySettings_Area_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);






            var platformManages = context.GetPermissionOrNull(SpartanPermissionNames.PlatformManages);
            if (platformManages == null)
            {
                platformManages = context.CreatePermission(SpartanPermissionNames.PlatformManages, L("平台管理"));
            }

            var platformManageUser=  platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_User, L("客户管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManageRole = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_Role, L("角色管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(SpartanPermissionNames.PlatformManages_Role_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(SpartanPermissionNames.PlatformManages_Role_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageRole.CreateChildPermission(SpartanPermissionNames.PlatformManages_Role_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var platformManageDevice = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);


            var platformManageDeviceStatistics = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_DeviceStatistics, L("车辆统计"), multiTenancySides: MultiTenancySides.Host);
            var platformManageUserStatistics = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_UserStatistics, L("用户统计"), multiTenancySides: MultiTenancySides.Host);

            var platformManageDealRecord = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord, L("交易记录"), multiTenancySides: MultiTenancySides.Host);
            platformManageDealRecord.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);



            var systemManage = context.GetPermissionOrNull(SpartanPermissionNames.SystemManages);
            if (systemManage == null)
            {
                systemManage = context.CreatePermission(SpartanPermissionNames.SystemManages, L("系统管理"), multiTenancySides: MultiTenancySides.Host);
            }

            var systemManageTenant = systemManage.CreateChildPermission(SpartanPermissionNames.SystemManages_Tenant, L("租户管理"), multiTenancySides: MultiTenancySides.Host);
            systemManageTenant.CreateChildPermission(SpartanPermissionNames.SystemManages_Tenant_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            systemManageTenant.CreateChildPermission(SpartanPermissionNames.SystemManages_Tenant_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);
            systemManageTenant.CreateChildPermission(SpartanPermissionNames.SystemManages_Tenant_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);
            systemManageTenant.CreateChildPermission(SpartanPermissionNames.SystemManages_Tenant_Deposit, L("充值"), multiTenancySides: MultiTenancySides.Host);

            var systemManageDeviceType = systemManage.CreateChildPermission(SpartanPermissionNames.SystemManages_DeviceType, L("设备类型"), multiTenancySides: MultiTenancySides.Host);
            systemManageDeviceType.CreateChildPermission(SpartanPermissionNames.SystemManages_DeviceType_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);

            var systemManageNodes = systemManage.CreateChildPermission(SpartanPermissionNames.SystemManages_Node, multiTenancySides: MultiTenancySides.Host);
            systemManageNodes.CreateChildPermission(SpartanPermissionNames.SystemManages_Node_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            systemManageNodes.CreateChildPermission(SpartanPermissionNames.SystemManages_Node_Update, L("修改"), multiTenancySides: MultiTenancySides.Host);

            var systemManageAuditLog = systemManage.CreateChildPermission(SpartanPermissionNames.SystemManages_AuditLog, L("审计日志"), multiTenancySides: MultiTenancySides.Host);
            systemManageAuditLog.CreateChildPermission(SpartanPermissionNames.SystemManages_AuditLog_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

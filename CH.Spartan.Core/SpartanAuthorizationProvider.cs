using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CH.Spartan
{
    public class SpartanAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //客户
            var customers = context.GetPermissionOrNull(SpartanPermissionNames.Customers);
            if (customers == null)
            {
                customers = context.CreatePermission(SpartanPermissionNames.Customers, L("我的主页"), multiTenancySides: MultiTenancySides.Tenant);
            }
            customers.CreateChildPermission(SpartanPermissionNames.Customers_Monitor, L("定位监控"), multiTenancySides: MultiTenancySides.Tenant);
            customers.CreateChildPermission(SpartanPermissionNames.Customers_HistoryTrack, L("历史轨迹"), multiTenancySides: MultiTenancySides.Tenant);
            customers.CreateChildPermission(SpartanPermissionNames.Customers_Notification, L("报警信息"), multiTenancySides: MultiTenancySides.Tenant);
            customers.CreateChildPermission(SpartanPermissionNames.Customers_MileageReport, L("里程统计"), multiTenancySides: MultiTenancySides.Tenant);

            var customersSettings = context.GetPermissionOrNull(SpartanPermissionNames.Customers_Setting);
            if (customersSettings == null)
            {
                customersSettings = context.CreatePermission(SpartanPermissionNames.Customers_Setting, L("我的设置"), multiTenancySides: MultiTenancySides.Tenant);
            }

            var customersSettingDevice =  customersSettings.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Device, L("车辆设置"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingDevice.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingDevice.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingDevice.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var customersSettingArea= customersSettings.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Area, L("区域设置"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingArea.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Area_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingArea.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Area_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            customersSettingArea.CreateChildPermission(SpartanPermissionNames.Customers_Setting_Area_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            //代理
            var agentManages = context.GetPermissionOrNull(SpartanPermissionNames.AgentManages);
            if (agentManages == null)
            {
                agentManages = context.CreatePermission(SpartanPermissionNames.AgentManages, L("代理管理"), multiTenancySides: MultiTenancySides.Tenant);
            }

            var agentManageUser = agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_User, L("客户管理"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageUser.CreateChildPermission(SpartanPermissionNames.AgentManages_User_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageUser.CreateChildPermission(SpartanPermissionNames.AgentManages_User_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageUser.CreateChildPermission(SpartanPermissionNames.AgentManages_User_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var agentManageRole = agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_Role, L("角色管理"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageRole.CreateChildPermission(SpartanPermissionNames.AgentManages_Role_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageRole.CreateChildPermission(SpartanPermissionNames.AgentManages_Role_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageRole.CreateChildPermission(SpartanPermissionNames.AgentManages_Role_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var agentManageDevice = agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDevice.CreateChildPermission(SpartanPermissionNames.AgentManages_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDevice.CreateChildPermission(SpartanPermissionNames.AgentManages_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDevice.CreateChildPermission(SpartanPermissionNames.AgentManages_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);



            //平台
            var platformManages = context.GetPermissionOrNull(SpartanPermissionNames.PlatformManages);
            if (platformManages == null)
            {
                platformManages = context.CreatePermission(SpartanPermissionNames.PlatformManages, L("平台管理"), multiTenancySides: MultiTenancySides.Host);
            }

            var platformManageUser=  platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_User, L("客户管理"), multiTenancySides: MultiTenancySides.Host);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);
            platformManageUser.CreateChildPermission(SpartanPermissionNames.PlatformManages_User_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);

            var platformManageDevice = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Host);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Host);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Host);
            platformManageDevice.CreateChildPermission(SpartanPermissionNames.PlatformManages_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);
           
            var platformManageDealRecord = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord, L("交易记录"), multiTenancySides: MultiTenancySides.Host);
            platformManageDealRecord.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);

            //系统
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

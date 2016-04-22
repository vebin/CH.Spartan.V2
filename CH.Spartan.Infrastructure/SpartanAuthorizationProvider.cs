using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CH.Spartan.Infrastructure
{
    public class SpartanAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //客户--------------------------------------------------------------------
            var customerManages = context.GetPermissionOrNull(SpartanPermissionNames.CustomerManages) ??
                            context.CreatePermission(SpartanPermissionNames.CustomerManages, L("客户管理"), multiTenancySides: MultiTenancySides.Tenant);
            customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_Monitor, L("定位监控"), multiTenancySides: MultiTenancySides.Tenant);
            customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_HistoryTrack, L("历史轨迹"), multiTenancySides: MultiTenancySides.Tenant);
            customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_Notification, L("报警信息"), multiTenancySides: MultiTenancySides.Tenant);
            customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_MileageReport, L("里程统计"), multiTenancySides: MultiTenancySides.Tenant);

            var customerManageDevice = customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_Device, L("车辆管理"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageDevice.CreateChildPermission(SpartanPermissionNames.CustomerManages_Device_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageDevice.CreateChildPermission(SpartanPermissionNames.CustomerManages_Device_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageDevice.CreateChildPermission(SpartanPermissionNames.CustomerManages_Device_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var customerManageArea = customerManages.CreateChildPermission(SpartanPermissionNames.CustomerManages_Area, L("区域管理"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageArea.CreateChildPermission(SpartanPermissionNames.CustomerManages_Area_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageArea.CreateChildPermission(SpartanPermissionNames.CustomerManages_Area_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            customerManageArea.CreateChildPermission(SpartanPermissionNames.CustomerManages_Area_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            //代理--------------------------------------------------------------------
            var agentManages = context.GetPermissionOrNull(SpartanPermissionNames.AgentManages) ??
                               context.CreatePermission(SpartanPermissionNames.AgentManages, L("代理管理"), multiTenancySides: MultiTenancySides.Tenant);

            agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_Monitor, L("定位监控"), multiTenancySides: MultiTenancySides.Tenant);
            agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_HistoryTrack, L("历史轨迹"), multiTenancySides: MultiTenancySides.Tenant);
            agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_Notification, L("报警信息"), multiTenancySides: MultiTenancySides.Tenant);
            agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_MileageReport, L("里程统计"), multiTenancySides: MultiTenancySides.Tenant);


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

            var agentManageDeviceStock = agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_DeviceStock, L("库存管理"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDeviceStock.CreateChildPermission(SpartanPermissionNames.AgentManages_DeviceStock_Create, L("添加"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDeviceStock.CreateChildPermission(SpartanPermissionNames.AgentManages_DeviceStock_Update, L("更新"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDeviceStock.CreateChildPermission(SpartanPermissionNames.AgentManages_DeviceStock_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            var agentManageDealRecord = agentManages.CreateChildPermission(SpartanPermissionNames.AgentManages_DealRecord, L("交易记录"), multiTenancySides: MultiTenancySides.Tenant);
            agentManageDealRecord.CreateChildPermission(SpartanPermissionNames.AgentManages_DealRecord_Delete, L("删除"), multiTenancySides: MultiTenancySides.Tenant);

            //平台--------------------------------------------------------------------
            var platformManages = context.GetPermissionOrNull(SpartanPermissionNames.PlatformManages) ??
                                  context.CreatePermission(SpartanPermissionNames.PlatformManages, L("平台管理"), multiTenancySides: MultiTenancySides.Host);

            var platformManageDealRecord = platformManages.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord, L("交易记录"), multiTenancySides: MultiTenancySides.Host);
            platformManageDealRecord.CreateChildPermission(SpartanPermissionNames.PlatformManages_DealRecord_Delete, L("删除"), multiTenancySides: MultiTenancySides.Host);

            //系统--------------------------------------------------------------------
            var systemManage = context.GetPermissionOrNull(SpartanPermissionNames.SystemManages) ??
                               context.CreatePermission(SpartanPermissionNames.SystemManages, L("系统管理"), multiTenancySides: MultiTenancySides.Host);

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

            var systemManageJob = systemManage.CreateChildPermission(SpartanPermissionNames.SystemManages_Job, L("调度任务"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }
    }
}

namespace CH.Spartan.Infrastructure
{
    public static class SpartanPermissionNames
    {
     
        //客户
        public const string Customers = "Customers";
        public const string Customers_Monitor = "Customers.Monitor";
        public const string Customers_HistoryTrack = "Customers.HistoryTrack";
        public const string Customers_Notification = "Customers.Notification";
        public const string Customers_MileageReport = "Customers.MileageReport";

        public const string Customers_Setting = "Customers_Setting";
        public const string Customers_Setting_Device = "Customers_Setting.Device";
        public const string Customers_Setting_Device_Create = "Customers_Setting.Device.Create";
        public const string Customers_Setting_Device_Update = "Customers_Setting.Device.Update";
        public const string Customers_Setting_Device_Delete = "Customers_Setting.Device.Delete";

        public const string Customers_Setting_Area = "Customers_Setting.Area";
        public const string Customers_Setting_Area_Create = "Customers_Setting.Area.Create";
        public const string Customers_Setting_Area_Update = "Customers_Setting.Area.Update";
        public const string Customers_Setting_Area_Delete = "Customers_Setting.Area.Delete";
        
        //代理
        public const string AgentManages = "AgentManages";
        public const string AgentManages_User = "AgentManages.User";
        public const string AgentManages_User_Create = "AgentManages.User.Create";
        public const string AgentManages_User_Update = "AgentManages.User.Update";
        public const string AgentManages_User_Delete = "AgentManages.User.Delete";

        public const string AgentManages_Role = "AgentManages.Role";
        public const string AgentManages_Role_Create = "AgentManages.Role.Create";
        public const string AgentManages_Role_Update = "AgentManages.Role.Update";
        public const string AgentManages_Role_Delete = "AgentManages.Role.Delete";

        public const string AgentManages_Device = "AgentManages.Device";
        public const string AgentManages_Device_Create = "AgentManages.Device.Create";
        public const string AgentManages_Device_Update = "AgentManages.Device.Update";
        public const string AgentManages_Device_Delete = "AgentManages.Device.Delete";

        public const string AgentManages_DeviceStock = "AgentManages.DeviceStock";
        public const string AgentManages_DeviceStock_Create = "AgentManages.DeviceStock.Create";
        public const string AgentManages_DeviceStock_Update = "AgentManages.DeviceStock.Update";
        public const string AgentManages_DeviceStock_Delete = "AgentManages.DeviceStock.Delete";
      

        public const string AgentManages_DealRecord = "AgentManages.DealRecord";
        public const string AgentManages_DealRecord_Delete = "AgentManages.DealRecord.Delete";

        //平台
        public const string PlatformManages = "PlatformManages";

        public const string PlatformManages_DealRecord = "PlatformManages.DealRecord";
        public const string PlatformManages_DealRecord_Delete = "PlatformManages.DealRecord.Delete";


        //系统
        public const string SystemManages = "SystemManages";

        public const string SystemManages_Tenant = "SystemManages.Tenant";
        public const string SystemManages_Tenant_Create = "SystemManages.Tenant.Create";
        public const string SystemManages_Tenant_Update = "SystemManages.Tenant.Update";
        public const string SystemManages_Tenant_Delete = "SystemManages.Tenant.Delete";
        public const string SystemManages_Tenant_Deposit = "SystemManages.Tenant.Deposit";

        public const string SystemManages_DeviceType = "SystemManages.DeviceType";
        public const string SystemManages_DeviceType_Update = "SystemManages.DeviceType.Update";

        public const string SystemManages_Node = "SystemManages.Node";
        public const string SystemManages_Node_Create = "SystemManages.Node.Create";
        public const string SystemManages_Node_Update = "SystemManages.Node.Update";

        public const string SystemManages_AuditLog = "PlatformManages.AuditLog";
        public const string SystemManages_AuditLog_Delete = "PlatformManages.AuditLog.Delete";

        public const string SystemManages_Job = "PlatformManages.Job";
    }
}
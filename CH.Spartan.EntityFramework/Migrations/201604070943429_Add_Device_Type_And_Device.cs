namespace CH.Spartan.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Device_Type_And_Device : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Protocol = c.Int(nullable: false),
                        CodeCreateRule = c.Int(nullable: false),
                        IsHaveRelay = c.Boolean(nullable: false),
                        IsHaveMainPowerBreak = c.Boolean(nullable: false),
                        IsHaveSos = c.Boolean(nullable: false),
                        IsHaveDropOff = c.Boolean(nullable: false),
                        IsHaveShake = c.Boolean(nullable: false),
                        IsHaveLowBattery = c.Boolean(nullable: false),
                        IsHavePower = c.Boolean(nullable: false),
                        IsHaveAcc = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DeviceType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        BIconType = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        BDeviceTypeId = c.Int(nullable: false),
                        BNo = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        BCode = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        BSimNo = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        BExpireTime = c.DateTime(precision: 0),
                        BUserId = c.Int(nullable: false),
                        BNodeId = c.Int(nullable: false),
                        SIsEnableAlarm = c.Boolean(nullable: false),
                        SIsSendEmail = c.Boolean(nullable: false),
                        SIsSendApp = c.Boolean(nullable: false),
                        SReceiveEmails = c.String(maxLength: 250, storeType: "nvarchar"),
                        SReceiveStartTime = c.Time(nullable: false, precision: 0),
                        SReceiveEndTime = c.Time(nullable: false, precision: 0),
                        SLimitSpeed = c.Int(nullable: false),
                        SInOutArea = c.Boolean(nullable: false),
                        SFortifyRadius = c.Int(nullable: false),
                        GDirection = c.Int(nullable: false),
                        GHeight = c.Double(nullable: false),
                        GLatitude = c.Double(nullable: false),
                        GLongitude = c.Double(nullable: false),
                        GSpeed = c.Double(nullable: false),
                        GReportTime = c.DateTime(nullable: false, precision: 0),
                        GReceiveTime = c.DateTime(nullable: false, precision: 0),
                        GIsLocated = c.Boolean(nullable: false),
                        CIsAccOn = c.Boolean(nullable: false),
                        CPower = c.Int(nullable: false),
                        CIsRelayEnable = c.Boolean(nullable: false),
                        CRelayBreakTime = c.DateTime(precision: 0),
                        CIsMainPowerBreak = c.Boolean(nullable: false),
                        CMainPowerBreakTime = c.DateTime(precision: 0),
                        CMainPowerBreakLastAlarmTime = c.DateTime(precision: 0),
                        CIsSos = c.Boolean(nullable: false),
                        COverSpeedTime = c.DateTime(precision: 0),
                        COverSpeedLastAlarmTime = c.DateTime(precision: 0),
                        CInAreaList = c.String(maxLength: 500, storeType: "nvarchar"),
                        CIsFortify = c.Boolean(nullable: false),
                        CFortifyLatLng = c.String(maxLength: 100, storeType: "nvarchar"),
                        CLeaveFortifyAreaTime = c.DateTime(precision: 0),
                        CLeaveFortifyAreaLastAlarmTime = c.DateTime(precision: 0),
                        CLastHaveSpeedTime = c.DateTime(precision: 0),
                        CIsDropOff = c.Boolean(nullable: false),
                        CDropOffTime = c.DateTime(precision: 0),
                        CDropOffLastAlarmTime = c.DateTime(precision: 0),
                        CIsShake = c.Boolean(nullable: false),
                        CShakeTime = c.DateTime(precision: 0),
                        CIsLowBattery = c.Boolean(nullable: false),
                        CLowBatteryTime = c.DateTime(precision: 0),
                        CLowBatteryLastAlarmTime = c.DateTime(precision: 0),
                        CIsInBlindArea = c.Boolean(nullable: false),
                        CInBlindAreaTime = c.DateTime(precision: 0),
                        CInBlindAreaLastAlarmTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Device_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceTypes", t => t.BDeviceTypeId, cascadeDelete: true)
                .Index(t => t.BDeviceTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "BDeviceTypeId", "dbo.DeviceTypes");
            DropIndex("dbo.Devices", new[] { "BDeviceTypeId" });
            DropTable("dbo.Devices",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Device_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DeviceTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DeviceType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

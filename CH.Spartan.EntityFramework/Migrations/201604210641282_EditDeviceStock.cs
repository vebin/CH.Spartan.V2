namespace CH.Spartan.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class EditDeviceStock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        TenantId = c.Int(nullable: false),
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
                    { "DynamicFilter_DeviceStock_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DeviceStock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceStocks", "TenantId", "dbo.AbpTenants");
            DropIndex("dbo.DeviceStocks", new[] { "TenantId" });
            DropTable("dbo.DeviceStocks",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DeviceStock_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DeviceStock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

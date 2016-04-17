namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Device : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealRecords", "No", c => c.String(maxLength: 250, storeType: "nvarchar"));
            AddColumn("dbo.DealRecords", "OutNo", c => c.String(maxLength: 250, storeType: "nvarchar"));
            AddColumn("dbo.Devices", "BDscription", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AddColumn("dbo.Nodes", "UsageCount", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "BLicensePlate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "BLicensePlate", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
            DropColumn("dbo.Nodes", "UsageCount");
            DropColumn("dbo.Devices", "BDscription");
            DropColumn("dbo.DealRecords", "OutNo");
            DropColumn("dbo.DealRecords", "No");
        }
    }
}

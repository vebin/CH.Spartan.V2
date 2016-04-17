namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Device1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "GReportTime", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Devices", "GReceiveTime", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "GReceiveTime", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Devices", "GReportTime", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}

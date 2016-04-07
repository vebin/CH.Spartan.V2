namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DeviceTypes", "Protocol");
            DropColumn("dbo.DeviceTypes", "CodeCreateRule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceTypes", "CodeCreateRule", c => c.Int(nullable: false));
            AddColumn("dbo.DeviceTypes", "Protocol", c => c.Int(nullable: false));
        }
    }
}

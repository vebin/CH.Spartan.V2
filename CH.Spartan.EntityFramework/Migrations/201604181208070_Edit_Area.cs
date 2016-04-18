namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Area : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "SInOutArea", c => c.String(unicode: false));
            DropColumn("dbo.Areas", "Type");
            DropColumn("dbo.Areas", "Radius");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Areas", "Radius", c => c.Int());
            AddColumn("dbo.Areas", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "SInOutArea", c => c.Boolean(nullable: false));
        }
    }
}

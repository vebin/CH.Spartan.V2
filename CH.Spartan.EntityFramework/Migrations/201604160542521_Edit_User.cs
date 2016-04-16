namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "IsStatic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "IsStatic");
        }
    }
}

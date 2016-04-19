namespace CH.Spartan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDealRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealRecords", "IsSucceed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealRecords", "IsSucceed");
        }
    }
}

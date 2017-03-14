namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoningClearance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ZoningClearances", "BusinessAddress", c => c.String(nullable: false));
            DropColumn("dbo.ZoningClearances", "BusinessAdress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZoningClearances", "BusinessAdress", c => c.String(nullable: false));
            DropColumn("dbo.ZoningClearances", "BusinessAddress");
        }
    }
}

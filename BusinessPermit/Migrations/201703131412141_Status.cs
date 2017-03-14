namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationalClearances", "Status", c => c.String());
            AddColumn("dbo.ZoningClearances", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZoningClearances", "Status");
            DropColumn("dbo.LocationalClearances", "Status");
        }
    }
}

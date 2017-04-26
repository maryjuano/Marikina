namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingPermits", "PaymentReference", c => c.String());
            AddColumn("dbo.LocationalClearances", "PaymentReference", c => c.String());
            AddColumn("dbo.BusinessPermits", "PaymentReference", c => c.String());
            AddColumn("dbo.ZoningClearances", "PaymentReference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZoningClearances", "PaymentReference");
            DropColumn("dbo.BusinessPermits", "PaymentReference");
            DropColumn("dbo.LocationalClearances", "PaymentReference");
            DropColumn("dbo.BuildingPermits", "PaymentReference");
        }
    }
}

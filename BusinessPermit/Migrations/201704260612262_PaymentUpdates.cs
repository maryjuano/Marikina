namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingPermits", "TotalPayment", c => c.Single(nullable: false));
            AddColumn("dbo.LocationalClearances", "TotalPayment", c => c.Single(nullable: false));
            AddColumn("dbo.BusinessPermits", "TotalPayment", c => c.Single(nullable: false));
            AddColumn("dbo.ZoningClearances", "TotalPayment", c => c.Single(nullable: false));
            AddColumn("dbo.Payments", "TotalPayment", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "TotalPayment");
            DropColumn("dbo.ZoningClearances", "TotalPayment");
            DropColumn("dbo.BusinessPermits", "TotalPayment");
            DropColumn("dbo.LocationalClearances", "TotalPayment");
            DropColumn("dbo.BuildingPermits", "TotalPayment");
        }
    }
}

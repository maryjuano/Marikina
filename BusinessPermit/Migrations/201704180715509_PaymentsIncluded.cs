namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentsIncluded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fees", "LocationalClearance_LocationalClearanceId", c => c.Int());
            AddColumn("dbo.Fees", "ZoningClearance_ZoningClearanceId", c => c.Int());
            CreateIndex("dbo.Fees", "LocationalClearance_LocationalClearanceId");
            CreateIndex("dbo.Fees", "ZoningClearance_ZoningClearanceId");
            AddForeignKey("dbo.Fees", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances", "LocationalClearanceId");
            AddForeignKey("dbo.Fees", "ZoningClearance_ZoningClearanceId", "dbo.ZoningClearances", "ZoningClearanceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "ZoningClearance_ZoningClearanceId", "dbo.ZoningClearances");
            DropForeignKey("dbo.Fees", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.Fees", new[] { "ZoningClearance_ZoningClearanceId" });
            DropIndex("dbo.Fees", new[] { "LocationalClearance_LocationalClearanceId" });
            DropColumn("dbo.Fees", "ZoningClearance_ZoningClearanceId");
            DropColumn("dbo.Fees", "LocationalClearance_LocationalClearanceId");
        }
    }
}

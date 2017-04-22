namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessPermitUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessPermits", "LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.BusinessPermits", new[] { "LocationalClearanceId" });
            AddColumn("dbo.BusinessPermits", "ZoningClearanceReferenceNumber", c => c.String());
            AddColumn("dbo.BusinessPermits", "ZoningClearanceId", c => c.Int(nullable: false));
            CreateIndex("dbo.BusinessPermits", "ZoningClearanceId");
            AddForeignKey("dbo.BusinessPermits", "ZoningClearanceId", "dbo.ZoningClearances", "ZoningClearanceId", cascadeDelete: true);
            DropColumn("dbo.BusinessPermits", "LocationalClearanceReferenceNumber");
            DropColumn("dbo.BusinessPermits", "LocationalClearanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessPermits", "LocationalClearanceId", c => c.Int(nullable: false));
            AddColumn("dbo.BusinessPermits", "LocationalClearanceReferenceNumber", c => c.String());
            DropForeignKey("dbo.BusinessPermits", "ZoningClearanceId", "dbo.ZoningClearances");
            DropIndex("dbo.BusinessPermits", new[] { "ZoningClearanceId" });
            DropColumn("dbo.BusinessPermits", "ZoningClearanceId");
            DropColumn("dbo.BusinessPermits", "ZoningClearanceReferenceNumber");
            CreateIndex("dbo.BusinessPermits", "LocationalClearanceId");
            AddForeignKey("dbo.BusinessPermits", "LocationalClearanceId", "dbo.LocationalClearances", "LocationalClearanceId", cascadeDelete: true);
        }
    }
}

namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingPermitUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingPermits", "LocationalId", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId", c => c.Int());
            CreateIndex("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId");
            AddForeignKey("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances", "LocationalClearanceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.BuildingPermits", new[] { "LocationalClearance_LocationalClearanceId" });
            DropColumn("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId");
            DropColumn("dbo.BuildingPermits", "LocationalId");
        }
    }
}

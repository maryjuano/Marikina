namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationalId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.BuildingPermits", new[] { "LocationalClearance_LocationalClearanceId" });
            RenameColumn(table: "dbo.BuildingPermits", name: "LocationalClearance_LocationalClearanceId", newName: "LocationalClearanceId");
            AlterColumn("dbo.BuildingPermits", "LocationalClearanceId", c => c.Int(nullable: false));
            CreateIndex("dbo.BuildingPermits", "LocationalClearanceId");
            AddForeignKey("dbo.BuildingPermits", "LocationalClearanceId", "dbo.LocationalClearances", "LocationalClearanceId", cascadeDelete: true);
            DropColumn("dbo.BuildingPermits", "LocationalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuildingPermits", "LocationalId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BuildingPermits", "LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.BuildingPermits", new[] { "LocationalClearanceId" });
            AlterColumn("dbo.BuildingPermits", "LocationalClearanceId", c => c.Int());
            RenameColumn(table: "dbo.BuildingPermits", name: "LocationalClearanceId", newName: "LocationalClearance_LocationalClearanceId");
            CreateIndex("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId");
            AddForeignKey("dbo.BuildingPermits", "LocationalClearance_LocationalClearanceId", "dbo.LocationalClearances", "LocationalClearanceId");
        }
    }
}

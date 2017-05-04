namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bebeko : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuildingPermits", "LocationLotNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LocationBlockNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LocationTCTNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LocationStreet", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LocationBarangay", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LocationCity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuildingPermits", "LocationCity", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LocationBarangay", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LocationStreet", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LocationTCTNumber", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LocationBlockNumber", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LocationLotNumber", c => c.String());
        }
    }
}

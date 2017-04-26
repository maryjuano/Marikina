namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingPermits", "LocationaClearanceReference", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "AreaNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "TIN", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "TelephoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuildingPermits", "ScopeOfWorkOther", c => c.String(nullable: false));
            DropColumn("dbo.BuildingPermits", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuildingPermits", "Owner", c => c.String());
            AlterColumn("dbo.BuildingPermits", "ScopeOfWorkOther", c => c.String());
            AlterColumn("dbo.BuildingPermits", "TelephoneNumber", c => c.String());
            AlterColumn("dbo.BuildingPermits", "TIN", c => c.String());
            AlterColumn("dbo.BuildingPermits", "FirstName", c => c.String());
            AlterColumn("dbo.BuildingPermits", "LastName", c => c.String());
            AlterColumn("dbo.BuildingPermits", "AreaNumber", c => c.String());
            DropColumn("dbo.BuildingPermits", "LocationaClearanceReference");
        }
    }
}

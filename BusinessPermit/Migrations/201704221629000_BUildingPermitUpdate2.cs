namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BUildingPermitUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingPermits", "BuildingTypePermit", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingPermits", "ScopeOfWork", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingPermits", "ScopeOfWorkOther", c => c.String());
            AddColumn("dbo.BuildingPermits", "BuildingUse", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingPermits", "BuildingUseOther", c => c.String());
            AddColumn("dbo.BuildingPermits", "OccupancyClassified", c => c.String());
            AddColumn("dbo.BuildingPermits", "NumberOfUnits", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingPermits", "TotalFloorArea", c => c.Double(nullable: false));
            AddColumn("dbo.BuildingPermits", "TotalEstimatedCost", c => c.Single(nullable: false));
            AddColumn("dbo.BuildingPermits", "ProposedConstructionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingPermits", "ExpectedCompletionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BuildingPermits", "New");
            DropColumn("dbo.BuildingPermits", "Renewal");
            DropColumn("dbo.BuildingPermits", "Amendatory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuildingPermits", "Amendatory", c => c.Boolean(nullable: false));
            AddColumn("dbo.BuildingPermits", "Renewal", c => c.Boolean(nullable: false));
            AddColumn("dbo.BuildingPermits", "New", c => c.Boolean(nullable: false));
            DropColumn("dbo.BuildingPermits", "ExpectedCompletionDate");
            DropColumn("dbo.BuildingPermits", "ProposedConstructionDate");
            DropColumn("dbo.BuildingPermits", "TotalEstimatedCost");
            DropColumn("dbo.BuildingPermits", "TotalFloorArea");
            DropColumn("dbo.BuildingPermits", "NumberOfUnits");
            DropColumn("dbo.BuildingPermits", "OccupancyClassified");
            DropColumn("dbo.BuildingPermits", "BuildingUseOther");
            DropColumn("dbo.BuildingPermits", "BuildingUse");
            DropColumn("dbo.BuildingPermits", "ScopeOfWorkOther");
            DropColumn("dbo.BuildingPermits", "ScopeOfWork");
            DropColumn("dbo.BuildingPermits", "BuildingTypePermit");
        }
    }
}

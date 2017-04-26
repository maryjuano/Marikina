namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFieldUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuildingPermits", "ScopeOfWorkOther", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuildingPermits", "ScopeOfWorkOther", c => c.String(nullable: false));
        }
    }
}

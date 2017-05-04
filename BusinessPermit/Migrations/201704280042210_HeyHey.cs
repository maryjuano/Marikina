namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeyHey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocationalClearances", "TCTNumber", c => c.String());
            AlterColumn("dbo.Payments", "ApplicationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "ApplicationType", c => c.Int());
            AlterColumn("dbo.LocationalClearances", "TCTNumber", c => c.String(nullable: false));
        }
    }
}

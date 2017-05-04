namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessPermits", "ContactNumber", c => c.String());
            AlterColumn("dbo.ZoningClearances", "ContactNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ZoningClearances", "ContactNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.BusinessPermits", "ContactNumber", c => c.Int(nullable: false));
        }
    }
}

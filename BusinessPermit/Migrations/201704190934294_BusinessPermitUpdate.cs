namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessPermitUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessPermits", "Attachments", c => c.Binary(nullable: false));
            AddColumn("dbo.BusinessPermits", "LocationalClearanceReferenceNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessPermits", "LocationalClearanceReferenceNumber");
            DropColumn("dbo.BusinessPermits", "Attachments");
        }
    }
}

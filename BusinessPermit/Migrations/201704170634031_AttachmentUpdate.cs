namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachmentUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocationalClearances", "Attachments", c => c.Binary(nullable: false));
            AlterColumn("dbo.ZoningClearances", "Attachments", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ZoningClearances", "Attachments", c => c.Binary());
            AlterColumn("dbo.LocationalClearances", "Attachments", c => c.Binary());
        }
    }
}

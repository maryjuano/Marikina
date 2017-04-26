namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "ApplicationNumber", c => c.String());
            AddColumn("dbo.Payments", "OfficialReceiptNumber", c => c.String());
            DropColumn("dbo.Payments", "DateApplied");
            DropColumn("dbo.Payments", "DatePaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "DatePaid", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "DateApplied", c => c.DateTime(nullable: false));
            DropColumn("dbo.Payments", "OfficialReceiptNumber");
            DropColumn("dbo.Payments", "ApplicationNumber");
        }
    }
}

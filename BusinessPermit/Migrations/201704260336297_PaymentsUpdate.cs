namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentsUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "ApplicationNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "ReferenceNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "OfficialReceiptNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "OfficialReceiptNumber", c => c.String());
            AlterColumn("dbo.Payments", "ReferenceNumber", c => c.String());
            AlterColumn("dbo.Payments", "ApplicationNumber", c => c.String());
        }
    }
}

namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentModification : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Payments", "ApplicationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "ApplicationNumber", c => c.String(nullable: false));
        }
    }
}

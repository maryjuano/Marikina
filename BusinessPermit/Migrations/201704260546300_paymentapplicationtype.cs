namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentapplicationtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "ApplicationType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "ApplicationType");
        }
    }
}

namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocationalClearances", "LCPermitNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocationalClearances", "LCPermitNumber", c => c.String(nullable: false));
        }
    }
}

namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        ReferenceNumber = c.String(),
                        ApplicationTypeId = c.Int(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        Requirements = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.ApplicationTypes", t => t.ApplicationTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationTypeId);
            
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Entity = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForms", "ApplicationTypeId", "dbo.ApplicationTypes");
            DropIndex("dbo.ApplicationForms", new[] { "ApplicationTypeId" });
            DropTable("dbo.Audits");
            DropTable("dbo.ApplicationForms");
        }
    }
}

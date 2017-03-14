namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoningForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZoningForms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        Zoning_ApplicationNumber = c.String(),
                        Zoning_DateApplied = c.DateTime(nullable: false),
                        Zoning_BusinessName = c.String(nullable: false),
                        Zoning_OwnerName = c.String(nullable: false),
                        Zoning_BusinessAdress = c.String(nullable: false),
                        Zoning_BusinessNature = c.String(nullable: false),
                        Zoning_ContactNumber = c.Int(nullable: false),
                        Zoning_MainOffice = c.String(nullable: false),
                        Zoning_TotalFloorArea = c.Int(nullable: false),
                        Zoning_FloorAreaBusiness = c.Int(nullable: false),
                        Zoning_Attachments = c.Binary(),
                        ApplicationTypeId = c.Int(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        Requirements = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.ApplicationTypes", t => t.ApplicationTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoningForms", "ApplicationTypeId", "dbo.ApplicationTypes");
            DropIndex("dbo.ZoningForms", new[] { "ApplicationTypeId" });
            DropTable("dbo.ZoningForms");
        }
    }
}

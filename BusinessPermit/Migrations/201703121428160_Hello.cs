namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hello : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZoningForms", "ApplicationTypeId", "dbo.ApplicationTypes");
            DropIndex("dbo.ZoningForms", new[] { "ApplicationTypeId" });
            CreateTable(
                "dbo.LocationalClearances",
                c => new
                    {
                        LocationalClearanceId = c.Int(nullable: false, identity: true),
                        ApplicationNumber = c.String(),
                        DateApplied = c.DateTime(nullable: false),
                        LCPermitNumber = c.String(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        Project = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Firm = c.String(nullable: false),
                        FloorArea = c.Double(nullable: false),
                        LandArea = c.Double(nullable: false),
                        UsableOpenSpace = c.Int(nullable: false),
                        TCTNumber = c.String(nullable: false),
                        Attachments = c.Binary(),
                    })
                .PrimaryKey(t => t.LocationalClearanceId);
            
            CreateTable(
                "dbo.ZoningClearances",
                c => new
                    {
                        ZoningClearanceId = c.Int(nullable: false, identity: true),
                        ApplicationNumber = c.String(),
                        DateApplied = c.DateTime(nullable: false),
                        BusinessName = c.String(nullable: false),
                        OwnerName = c.String(nullable: false),
                        BusinessAdress = c.String(nullable: false),
                        BusinessNature = c.String(nullable: false),
                        ContactNumber = c.Int(nullable: false),
                        MainOffice = c.String(nullable: false),
                        TotalFloorArea = c.Int(nullable: false),
                        FloorAreaBusiness = c.Int(nullable: false),
                        Attachments = c.Binary(),
                    })
                .PrimaryKey(t => t.ZoningClearanceId);
            
            DropTable("dbo.ZoningForms");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ApplicationId);
            
            DropTable("dbo.ZoningClearances");
            DropTable("dbo.LocationalClearances");
            CreateIndex("dbo.ZoningForms", "ApplicationTypeId");
            AddForeignKey("dbo.ZoningForms", "ApplicationTypeId", "dbo.ApplicationTypes", "ApplicationTypeId", cascadeDelete: true);
        }
    }
}

namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationForms", "Zoning_ApplicationNumber", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_DateApplied", c => c.DateTime());
            AddColumn("dbo.ApplicationForms", "Zoning_LCPermitNumber", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_DateIssued", c => c.DateTime());
            AddColumn("dbo.ApplicationForms", "Zoning_Project", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_Location", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_Address", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_Firm", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_FloorArea", c => c.Double());
            AddColumn("dbo.ApplicationForms", "Zoning_LandArea", c => c.Double());
            AddColumn("dbo.ApplicationForms", "Zoning_UsableOpenSpace", c => c.Int());
            AddColumn("dbo.ApplicationForms", "Zoning_TCTNumber", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_Attachments", c => c.Binary());
            AddColumn("dbo.ApplicationForms", "Zoning_ApplicationNumber1", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_DateApplied1", c => c.DateTime());
            AddColumn("dbo.ApplicationForms", "Zoning_BusinessName", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_OwnerName", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_BusinessAdress", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_BusinessNature", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_ContactNumber", c => c.Int());
            AddColumn("dbo.ApplicationForms", "Zoning_MainOffice", c => c.String());
            AddColumn("dbo.ApplicationForms", "Zoning_TotalFloorArea", c => c.Int());
            AddColumn("dbo.ApplicationForms", "Zoning_FloorAreaBusiness", c => c.Int());
            AddColumn("dbo.ApplicationForms", "Zoning_Attachments1", c => c.Binary());
            AddColumn("dbo.ApplicationForms", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.ApplicationForms", "ReferenceNumber");
            DropTable("dbo.LocationalClearances");
            DropTable("dbo.ZoningClearances");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.ApplicationForms", "ReferenceNumber", c => c.String());
            DropColumn("dbo.ApplicationForms", "Discriminator");
            DropColumn("dbo.ApplicationForms", "Zoning_Attachments1");
            DropColumn("dbo.ApplicationForms", "Zoning_FloorAreaBusiness");
            DropColumn("dbo.ApplicationForms", "Zoning_TotalFloorArea");
            DropColumn("dbo.ApplicationForms", "Zoning_MainOffice");
            DropColumn("dbo.ApplicationForms", "Zoning_ContactNumber");
            DropColumn("dbo.ApplicationForms", "Zoning_BusinessNature");
            DropColumn("dbo.ApplicationForms", "Zoning_BusinessAdress");
            DropColumn("dbo.ApplicationForms", "Zoning_OwnerName");
            DropColumn("dbo.ApplicationForms", "Zoning_BusinessName");
            DropColumn("dbo.ApplicationForms", "Zoning_DateApplied1");
            DropColumn("dbo.ApplicationForms", "Zoning_ApplicationNumber1");
            DropColumn("dbo.ApplicationForms", "Zoning_Attachments");
            DropColumn("dbo.ApplicationForms", "Zoning_TCTNumber");
            DropColumn("dbo.ApplicationForms", "Zoning_UsableOpenSpace");
            DropColumn("dbo.ApplicationForms", "Zoning_LandArea");
            DropColumn("dbo.ApplicationForms", "Zoning_FloorArea");
            DropColumn("dbo.ApplicationForms", "Zoning_Firm");
            DropColumn("dbo.ApplicationForms", "Zoning_Address");
            DropColumn("dbo.ApplicationForms", "Zoning_Location");
            DropColumn("dbo.ApplicationForms", "Zoning_Project");
            DropColumn("dbo.ApplicationForms", "Zoning_DateIssued");
            DropColumn("dbo.ApplicationForms", "Zoning_LCPermitNumber");
            DropColumn("dbo.ApplicationForms", "Zoning_DateApplied");
            DropColumn("dbo.ApplicationForms", "Zoning_ApplicationNumber");
        }
    }
}

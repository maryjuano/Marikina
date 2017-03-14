namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remodeling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationForms", "ApplicationTypeId", "dbo.ApplicationTypes");
            DropIndex("dbo.ApplicationForms", new[] { "ApplicationTypeId" });
            AddColumn("dbo.Fees", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Fees", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.Fees", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Fees", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.Fees", "CreatedBy_UserId", c => c.Int());
            AddColumn("dbo.Fees", "LastModifiedBy_UserId", c => c.Int());
            AddColumn("dbo.UserRoles", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoles", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoles", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.UserRoles", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.UserRoles", "CreatedBy_UserId", c => c.Int());
            AddColumn("dbo.UserRoles", "LastModifiedBy_UserId", c => c.Int());
            CreateIndex("dbo.UserRoles", "CreatedBy_UserId");
            CreateIndex("dbo.UserRoles", "LastModifiedBy_UserId");
            CreateIndex("dbo.Fees", "CreatedBy_UserId");
            CreateIndex("dbo.Fees", "LastModifiedBy_UserId");
            AddForeignKey("dbo.UserRoles", "CreatedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserRoles", "LastModifiedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Fees", "CreatedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Fees", "LastModifiedBy_UserId", "dbo.Users", "UserId");
            DropTable("dbo.ApplicationForms");
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        ApplicationTypeId = c.Int(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        Requirements = c.Binary(),
                        Status = c.String(),
                        Zoning_ApplicationNumber = c.String(),
                        Zoning_DateApplied = c.DateTime(),
                        Zoning_LCPermitNumber = c.String(),
                        Zoning_DateIssued = c.DateTime(),
                        Zoning_Project = c.String(),
                        Zoning_Location = c.String(),
                        Zoning_Address = c.String(),
                        Zoning_Firm = c.String(),
                        Zoning_FloorArea = c.Double(),
                        Zoning_LandArea = c.Double(),
                        Zoning_UsableOpenSpace = c.Int(),
                        Zoning_TCTNumber = c.String(),
                        Zoning_Attachments = c.Binary(),
                        Zoning_ApplicationNumber1 = c.String(),
                        Zoning_DateApplied1 = c.DateTime(),
                        Zoning_BusinessName = c.String(),
                        Zoning_OwnerName = c.String(),
                        Zoning_BusinessAdress = c.String(),
                        Zoning_BusinessNature = c.String(),
                        Zoning_ContactNumber = c.Int(),
                        Zoning_MainOffice = c.String(),
                        Zoning_TotalFloorArea = c.Int(),
                        Zoning_FloorAreaBusiness = c.Int(),
                        Zoning_Attachments1 = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            DropForeignKey("dbo.Fees", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Fees", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "CreatedBy_UserId", "dbo.Users");
            DropIndex("dbo.Fees", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Fees", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.UserRoles", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.UserRoles", new[] { "CreatedBy_UserId" });
            DropColumn("dbo.UserRoles", "LastModifiedBy_UserId");
            DropColumn("dbo.UserRoles", "CreatedBy_UserId");
            DropColumn("dbo.UserRoles", "LastModifiedOn");
            DropColumn("dbo.UserRoles", "CreatedOn");
            DropColumn("dbo.UserRoles", "LastModifiedById");
            DropColumn("dbo.UserRoles", "CreatedById");
            DropColumn("dbo.Fees", "LastModifiedBy_UserId");
            DropColumn("dbo.Fees", "CreatedBy_UserId");
            DropColumn("dbo.Fees", "LastModifiedOn");
            DropColumn("dbo.Fees", "CreatedOn");
            DropColumn("dbo.Fees", "LastModifiedById");
            DropColumn("dbo.Fees", "CreatedById");
            CreateIndex("dbo.ApplicationForms", "ApplicationTypeId");
            AddForeignKey("dbo.ApplicationForms", "ApplicationTypeId", "dbo.ApplicationTypes", "ApplicationTypeId", cascadeDelete: true);
        }
    }
}

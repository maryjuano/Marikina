namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationTypes",
                c => new
                    {
                        ApplicationTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationTypeId);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        FeeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        ApplicationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeeId)
                .ForeignKey("dbo.ApplicationTypes", t => t.ApplicationTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationTypeId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 24),
                        EmployeeId = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "ApplicationTypeId", "dbo.ApplicationTypes");
            DropIndex("dbo.Fees", new[] { "ApplicationTypeId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Status");
            DropTable("dbo.Fees");
            DropTable("dbo.ApplicationTypes");
        }
    }
}

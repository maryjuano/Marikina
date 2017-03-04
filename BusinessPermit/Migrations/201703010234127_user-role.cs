namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserRole_RoleId", c => c.Int());
            CreateIndex("dbo.Users", "UserRole_RoleId");
            AddForeignKey("dbo.Users", "UserRole_RoleId", "dbo.UserRoles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_RoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_RoleId" });
            DropColumn("dbo.Users", "UserRole_RoleId");
            DropColumn("dbo.Users", "UserRoleId");
        }
    }
}

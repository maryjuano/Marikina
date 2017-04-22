namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingPermit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingPermits",
                c => new
                    {
                        BuildingPermitId = c.Int(nullable: false, identity: true),
                        New = c.Boolean(nullable: false),
                        Renewal = c.Boolean(nullable: false),
                        Amendatory = c.Boolean(nullable: false),
                        ApplicationNumber = c.String(),
                        AreaNumber = c.String(),
                        Owner = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleInitial = c.String(),
                        TIN = c.String(),
                        FormOfOwnerShip = c.String(),
                        OwnerStreetNumber = c.String(),
                        OwnerStreet = c.String(),
                        OwnerBarangay = c.String(),
                        OwnerCity = c.String(),
                        OwnerZipCode = c.Int(nullable: false),
                        TelephoneNumber = c.String(),
                        LocationLotNumber = c.String(),
                        LocationBlockNumber = c.String(),
                        LocationTCTNumber = c.String(),
                        LocationTaxDescriptionNumber = c.String(),
                        LocationStreet = c.String(),
                        LocationBarangay = c.String(),
                        LocationCity = c.String(),
                        Attachment = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.BuildingPermitId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingPermits");
        }
    }
}

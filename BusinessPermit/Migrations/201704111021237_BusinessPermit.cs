namespace BusinessPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessPermit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessPermits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsNew = c.Boolean(nullable: false),
                        BusinessAccountNumber = c.Int(nullable: false),
                        DateApplied = c.DateTime(nullable: false),
                        BusinessName = c.String(),
                        OwnerName = c.String(),
                        BusinessAddress = c.String(),
                        BusinessNature = c.String(),
                        DeliveryVehicles = c.Int(nullable: false),
                        TotalAreaBusiness = c.Double(nullable: false),
                        ContactNumber = c.Int(nullable: false),
                        TotalEmployee = c.Int(nullable: false),
                        RentedOwnerName = c.String(),
                        MonthlyRental = c.Single(nullable: false),
                        JanGrossReceipt = c.Single(nullable: false),
                        FebGrossReceipt = c.Single(nullable: false),
                        MarGrossReceipt = c.Single(nullable: false),
                        AprGrossReceipt = c.Single(nullable: false),
                        MayGrossReceipt = c.Single(nullable: false),
                        JunGrossReceipt = c.Single(nullable: false),
                        JulGrossReceipt = c.Single(nullable: false),
                        AugGrossReceipt = c.Single(nullable: false),
                        SepGrossReceipt = c.Single(nullable: false),
                        OctGrossReceipt = c.Single(nullable: false),
                        NovGrossReceipt = c.Single(nullable: false),
                        DecGrossReceipt = c.Single(nullable: false),
                        TotalGrossReceipt = c.Single(nullable: false),
                        CapitalInvestment = c.Single(nullable: false),
                        DateStartedRemarks = c.String(),
                        CapitalInvestmentRemarks = c.String(),
                        AreaRemarks = c.String(),
                        GrossSalesPerDay = c.Single(nullable: false),
                        GrossSalesPerYear = c.Single(nullable: false),
                        PreviousBasisLicenseTax = c.String(),
                        CurrentBasisLicenseTax = c.String(),
                        AssessedAmount = c.Single(nullable: false),
                        Status = c.String(),
                        LocationalClearanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationalClearances", t => t.LocationalClearanceId, cascadeDelete: false)
                .Index(t => t.LocationalClearanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessPermits", "LocationalClearanceId", "dbo.LocationalClearances");
            DropIndex("dbo.BusinessPermits", new[] { "LocationalClearanceId" });
            DropTable("dbo.BusinessPermits");
        }
    }
}

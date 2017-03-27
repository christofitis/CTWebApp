namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startingRepairRouterModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairRouters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactDate = c.DateTime(nullable: false),
                        ContactedByPhone = c.Boolean(nullable: false),
                        ContactedByEmail = c.Boolean(nullable: false),
                        TalkedTo = c.String(),
                        isCODProduct = c.Boolean(nullable: false),
                        IsCodMoney = c.Boolean(nullable: false),
                        CurrentInQuickbooks = c.Boolean(nullable: false),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        ShopName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Cirt = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        ProdInQB = c.Boolean(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        PlaceOfPurchase = c.String(),
                        CoveredUnderWarranty = c.Boolean(nullable: false),
                        ProductModel = c.String(),
                        ProductGen = c.String(),
                        ProductSerialNumber = c.String(),
                        DidSendAdaptor = c.Boolean(nullable: false),
                        IsWarrentyRepair = c.Boolean(nullable: false),
                        IsReplaceRepackage = c.Boolean(nullable: false),
                        IsReferbishPkg = c.Boolean(nullable: false),
                        IsPaidRepair = c.Boolean(nullable: false),
                        PaidRepairAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnLabel = c.String(),
                        IsLoggedInQb = c.Boolean(nullable: false),
                        ShipType = c.String(),
                        DateReceived = c.DateTime(nullable: false),
                        RMAReceivedBy = c.String(),
                        IsWithinTheUSA = c.Boolean(nullable: false),
                        CustomerComplaint = c.String(),
                        SpecialInstructions = c.String(),
                        WasRepaired = c.Boolean(nullable: false),
                        WasReplaced = c.Boolean(nullable: false),
                        RepairDoneBy = c.String(),
                        RepairDate = c.DateTime(nullable: false),
                        OutSerialNumber = c.String(),
                        FirstTestDone = c.Boolean(nullable: false),
                        FirstTester = c.String(),
                        SecondTestDone = c.Boolean(nullable: false),
                        SecondTester = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RepairRouters");
        }
    }
}

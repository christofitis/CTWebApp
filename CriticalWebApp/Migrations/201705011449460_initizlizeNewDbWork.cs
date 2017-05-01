namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initizlizeNewDbWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartId = c.Int(nullable: false),
                        OffsiteJobId = c.Int(nullable: false),
                        QuantityAtJobSite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OffsiteJobs", t => t.OffsiteJobId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId)
                .Index(t => t.OffsiteJobId);
            
            CreateTable(
                "dbo.OffsiteJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PONumber = c.String(),
                        AssemblyHouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        JobQuantity = c.Int(nullable: false),
                        IssuedDate = c.DateTime(nullable: false),
                        QuantityOfProductDelivered = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssemblyHouses", t => t.AssemblyHouseId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.AssemblyHouseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        Name = c.String(nullable: false),
                        HardwareRevision = c.String(nullable: false),
                        SoftwareRevision = c.String(),
                        SerialNumberPrefix = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MFGNumber = c.String(),
                        Description = c.String(),
                        QuantityOnHand = c.Int(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductAssemblies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        QuantityPerProduct = c.Int(nullable: false),
                        LocationOnPcb = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.ProductionOutputTotals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Product = c.String(nullable: false),
                        Employee = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductReceiveds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceivedDate = c.DateTime(nullable: false),
                        Employee = c.String(),
                        NumberOfBoxes = c.Int(nullable: false),
                        QuantityOnBox = c.Int(nullable: false),
                        CountedQuantity = c.Int(nullable: false),
                        ReferenceNumber = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductionTotals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Product = c.String(),
                        QtyNeeded = c.Int(nullable: false),
                        QtyInShipping = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairRouters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactDate = c.DateTime(nullable: false, storeType: "date"),
                        ContactedByPhone = c.Boolean(nullable: false),
                        ContactedByEmail = c.Boolean(nullable: false),
                        TalkedTo = c.String(nullable: false),
                        isCODProduct = c.Boolean(nullable: false),
                        IsCodMoney = c.Boolean(nullable: false),
                        CurrentInQuickbooks = c.Boolean(nullable: false),
                        CustomerFirstName = c.String(nullable: false),
                        CustomerLastName = c.String(),
                        ShopName = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(),
                        ProdInQB = c.Boolean(nullable: false),
                        DateOfPurchase = c.DateTime(storeType: "date"),
                        PlaceOfPurchase = c.String(),
                        CoveredUnderWarranty = c.Boolean(nullable: false),
                        ProductModel = c.String(nullable: false),
                        ProductSerialNumber = c.String(),
                        IsWarrentyRepair = c.Boolean(nullable: false),
                        IsReplaceRepackage = c.Boolean(nullable: false),
                        IsReferbishPkg = c.Boolean(nullable: false),
                        PaidRepairAmount = c.Decimal(precision: 18, scale: 2),
                        ReturnLabel = c.String(),
                        ShipType = c.String(),
                        DateReceived = c.DateTime(storeType: "date"),
                        RMAReceivedBy = c.String(),
                        ProductReceived = c.Boolean(nullable: false),
                        OtherReceived = c.String(),
                        IsWithinTheUSA = c.Boolean(nullable: false),
                        CustomerComplaint = c.String(nullable: false),
                        SpecialInstructions = c.String(),
                        WasRepaired = c.Boolean(nullable: false),
                        WasReplaced = c.Boolean(nullable: false),
                        RepairNotes = c.String(),
                        RepairDoneBy = c.String(),
                        RepairDate = c.DateTime(storeType: "date"),
                        OutSerialNumber = c.String(),
                        FirstTester = c.String(),
                        SecondTester = c.String(),
                        Notes = c.String(),
                        Status = c.String(),
                        ProductCondition = c.String(),
                        ReceiptFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RepairDate = c.DateTime(nullable: false),
                        SerialNumber = c.String(nullable: false),
                        OutSerialNumber = c.String(),
                        InProduct = c.String(nullable: false),
                        InProductRevision = c.String(nullable: false),
                        OutProduct = c.String(),
                        OutProductRevision = c.String(),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerComplaint = c.String(),
                        IssueFound = c.String(nullable: false),
                        ActionTaken = c.String(nullable: false),
                        RouterImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SerialNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        MFGDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(),
                        InvoiceNumber = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SerialNumbers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductAssemblies", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAssemblies", "PartId", "dbo.Parts");
            DropForeignKey("dbo.JobInventories", "PartId", "dbo.Parts");
            DropForeignKey("dbo.JobInventories", "OffsiteJobId", "dbo.OffsiteJobs");
            DropForeignKey("dbo.OffsiteJobs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OffsiteJobs", "AssemblyHouseId", "dbo.AssemblyHouses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SerialNumbers", new[] { "ProductId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductAssemblies", new[] { "PartId" });
            DropIndex("dbo.ProductAssemblies", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "AssemblyHouseId" });
            DropIndex("dbo.JobInventories", new[] { "OffsiteJobId" });
            DropIndex("dbo.JobInventories", new[] { "PartId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SerialNumbers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Repairs");
            DropTable("dbo.RepairRouters");
            DropTable("dbo.ProductionTotals");
            DropTable("dbo.ProductReceiveds");
            DropTable("dbo.ProductionOutputTotals");
            DropTable("dbo.ProductAssemblies");
            DropTable("dbo.Parts");
            DropTable("dbo.Products");
            DropTable("dbo.OffsiteJobs");
            DropTable("dbo.JobInventories");
            DropTable("dbo.Customers");
            DropTable("dbo.AssemblyHouses");
        }
    }
}

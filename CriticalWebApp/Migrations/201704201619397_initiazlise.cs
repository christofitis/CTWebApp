namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiazlise : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductionOutputTotals", new[] { "ProductId" });
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
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MFGNumber = c.String(),
                        Description = c.String(),
                        QuantityOnHand = c.Int(),
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
            
            AddColumn("dbo.ProductionOutputTotals", "Product", c => c.String(nullable: false));
            AlterColumn("dbo.ProductionOutputTotals", "Employee", c => c.String(nullable: false));
            DropColumn("dbo.ProductionOutputTotals", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionOutputTotals", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductAssemblies", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAssemblies", "PartId", "dbo.Parts");
            DropForeignKey("dbo.JobInventories", "PartId", "dbo.Parts");
            DropForeignKey("dbo.JobInventories", "OffsiteJobId", "dbo.OffsiteJobs");
            DropForeignKey("dbo.OffsiteJobs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OffsiteJobs", "AssemblyHouseId", "dbo.AssemblyHouses");
            DropIndex("dbo.ProductAssemblies", new[] { "PartId" });
            DropIndex("dbo.ProductAssemblies", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "AssemblyHouseId" });
            DropIndex("dbo.JobInventories", new[] { "OffsiteJobId" });
            DropIndex("dbo.JobInventories", new[] { "PartId" });
            AlterColumn("dbo.ProductionOutputTotals", "Employee", c => c.String());
            DropColumn("dbo.ProductionOutputTotals", "Product");
            DropTable("dbo.ProductAssemblies");
            DropTable("dbo.Parts");
            DropTable("dbo.OffsiteJobs");
            DropTable("dbo.JobInventories");
            DropTable("dbo.AssemblyHouses");
            CreateIndex("dbo.ProductionOutputTotals", "ProductId");
            AddForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}

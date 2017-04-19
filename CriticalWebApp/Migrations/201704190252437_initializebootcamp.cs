namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializebootcamp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        PartPerProduct = c.Int(nullable: false),
                        LocationOnPcb = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductAssemblies", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAssemblies", "PartId", "dbo.Parts");
            DropForeignKey("dbo.OffsiteJobs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OffsiteJobs", "AssemblyHouseId", "dbo.AssemblyHouses");
            DropIndex("dbo.ProductAssemblies", new[] { "PartId" });
            DropIndex("dbo.ProductAssemblies", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "ProductId" });
            DropIndex("dbo.OffsiteJobs", new[] { "AssemblyHouseId" });
            DropTable("dbo.ProductAssemblies");
            DropTable("dbo.Parts");
            DropTable("dbo.OffsiteJobs");
            DropTable("dbo.AssemblyHouses");
        }
    }
}

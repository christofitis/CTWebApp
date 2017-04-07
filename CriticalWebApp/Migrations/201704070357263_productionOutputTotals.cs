namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productionOutputTotals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionOutputTotals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Employee = c.String(),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductionOutputTotals", new[] { "ProductId" });
            DropTable("dbo.ProductionOutputTotals");
        }
    }
}

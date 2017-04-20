namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productiontotals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductionOutputTotals", new[] { "ProductId" });
            AddColumn("dbo.ProductionOutputTotals", "Product", c => c.String());
            DropColumn("dbo.ProductionOutputTotals", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionOutputTotals", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductionOutputTotals", "Product");
            CreateIndex("dbo.ProductionOutputTotals", "ProductId");
            AddForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}

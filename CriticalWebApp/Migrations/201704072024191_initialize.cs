namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionOutputTotals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Employee = c.String(),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.ProductionTotals", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionOutputTotals", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductionOutputTotals", new[] { "ProductId" });
            DropColumn("dbo.ProductionTotals", "Date");
            DropTable("dbo.ProductionOutputTotals");
        }
    }
}

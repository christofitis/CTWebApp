namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class output : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductionOutputTotals", "Product", c => c.String(nullable: false));
            AlterColumn("dbo.ProductionOutputTotals", "Employee", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductionOutputTotals", "Employee", c => c.String());
            AlterColumn("dbo.ProductionOutputTotals", "Product", c => c.String());
        }
    }
}

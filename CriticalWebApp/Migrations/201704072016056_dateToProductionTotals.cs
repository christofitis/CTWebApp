namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateToProductionTotals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionOutputTotals", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOutputTotals", "Date");
        }
    }
}

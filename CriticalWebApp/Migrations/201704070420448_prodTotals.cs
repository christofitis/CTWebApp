namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodTotals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionTotals", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionTotals", "Date");
        }
    }
}

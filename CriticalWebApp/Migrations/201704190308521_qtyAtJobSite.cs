namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qtyAtJobSite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobInventories", "QuantityAtJobSite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobInventories", "QuantityAtJobSite");
        }
    }
}

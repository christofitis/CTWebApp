namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bfris : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "ProductCondition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairRouters", "ProductCondition");
        }
    }
}

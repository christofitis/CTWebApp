namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialie : DbMigration
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

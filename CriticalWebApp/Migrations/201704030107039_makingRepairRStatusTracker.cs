namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingRepairRStatusTracker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairRouters", "Status");
        }
    }
}

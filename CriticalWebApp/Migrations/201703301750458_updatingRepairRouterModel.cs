namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingRepairRouterModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RepairRouters", "ProductGen");
            DropColumn("dbo.RepairRouters", "DidSendPowerAdaptor");
            DropColumn("dbo.RepairRouters", "IsPaidRepair");
            DropColumn("dbo.RepairRouters", "IsLoggedInQb");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairRouters", "IsLoggedInQb", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "IsPaidRepair", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "DidSendPowerAdaptor", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "ProductGen", c => c.String());
        }
    }
}

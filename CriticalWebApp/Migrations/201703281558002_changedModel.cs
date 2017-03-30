namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "DidSendPowerAdaptor", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "ProductReceived", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "OtherReceived", c => c.String());
            DropColumn("dbo.RepairRouters", "DidSendAdaptor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairRouters", "DidSendAdaptor", c => c.Boolean(nullable: false));
            DropColumn("dbo.RepairRouters", "OtherReceived");
            DropColumn("dbo.RepairRouters", "ProductReceived");
            DropColumn("dbo.RepairRouters", "DidSendPowerAdaptor");
        }
    }
}

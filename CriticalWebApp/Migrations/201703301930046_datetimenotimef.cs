namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenotimef : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "DateOfPurchase", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.RepairRouters", "DateReceived", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.RepairRouters", "RepairDate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "RepairDate", c => c.DateTime());
            AlterColumn("dbo.RepairRouters", "DateReceived", c => c.DateTime());
            AlterColumn("dbo.RepairRouters", "DateOfPurchase", c => c.DateTime());
        }
    }
}

namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNullablkeDatTine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "DateOfPurchase", c => c.DateTime());
            AlterColumn("dbo.RepairRouters", "DateReceived", c => c.DateTime());
            AlterColumn("dbo.RepairRouters", "RepairDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "RepairDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RepairRouters", "DateReceived", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RepairRouters", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}

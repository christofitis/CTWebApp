namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNullableFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "ZipCode", c => c.Int());
            AlterColumn("dbo.RepairRouters", "PaidRepairAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "PaidRepairAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairRouters", "ZipCode", c => c.Int(nullable: false));
        }
    }
}

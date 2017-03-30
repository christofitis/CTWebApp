namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenotime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "ContactDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "ContactDate", c => c.DateTime(nullable: false));
        }
    }
}

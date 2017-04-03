namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredRemovedFromSerialNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SerialNumbers", "ShipDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SerialNumbers", "ShipDate", c => c.DateTime(nullable: false));
        }
    }
}

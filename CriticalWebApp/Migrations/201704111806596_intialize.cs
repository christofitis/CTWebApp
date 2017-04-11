namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SerialNumbers", "InvoiceNumber", c => c.String());
            AlterColumn("dbo.RepairRouters", "CustomerComplaint", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "CustomerComplaint", c => c.String());
            DropColumn("dbo.SerialNumbers", "InvoiceNumber");
        }
    }
}

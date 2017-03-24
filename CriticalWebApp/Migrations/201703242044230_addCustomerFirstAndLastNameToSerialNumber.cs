namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerFirstAndLastNameToSerialNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SerialNumbers", "CustomerFirstName", c => c.String());
            AddColumn("dbo.SerialNumbers", "CustomerLastName", c => c.String());
            DropColumn("dbo.SerialNumbers", "Customer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SerialNumbers", "Customer", c => c.String());
            DropColumn("dbo.SerialNumbers", "CustomerLastName");
            DropColumn("dbo.SerialNumbers", "CustomerFirstName");
        }
    }
}

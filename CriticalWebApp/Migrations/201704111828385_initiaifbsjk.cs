namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiaifbsjk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SerialNumbers", "InvoiceNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SerialNumbers", "InvoiceNumber");
        }
    }
}

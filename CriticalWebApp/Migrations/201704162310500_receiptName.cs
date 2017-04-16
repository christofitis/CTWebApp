namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class receiptName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "ReceiptFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairRouters", "ReceiptFileName");
        }
    }
}

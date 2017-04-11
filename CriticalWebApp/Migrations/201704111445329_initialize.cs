namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "CustomerComplaint", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "CustomerComplaint", c => c.String());
        }
    }
}

namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repairRouterNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairRouters", "Notes");
        }
    }
}

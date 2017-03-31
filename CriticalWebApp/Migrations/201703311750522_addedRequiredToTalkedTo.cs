namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequiredToTalkedTo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "TalkedTo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "TalkedTo", c => c.String());
        }
    }
}

namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRepairNoteProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "RepairNotes", c => c.String());
            DropColumn("dbo.RepairRouters", "FirstTestDone");
            DropColumn("dbo.RepairRouters", "SecondTestDone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairRouters", "SecondTestDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.RepairRouters", "FirstTestDone", c => c.Boolean(nullable: false));
            DropColumn("dbo.RepairRouters", "RepairNotes");
        }
    }
}

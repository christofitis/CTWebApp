namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairRouters", "City", c => c.String());
            AlterColumn("dbo.RepairRouters", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.RepairRouters", "Cirt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairRouters", "Cirt", c => c.String());
            AlterColumn("dbo.RepairRouters", "ZipCode", c => c.String());
            DropColumn("dbo.RepairRouters", "City");
        }
    }
}

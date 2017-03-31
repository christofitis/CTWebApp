namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequiredOnRouterModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.RepairRouters", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "Email", c => c.String());
            AlterColumn("dbo.RepairRouters", "Phone", c => c.String());
        }
    }
}

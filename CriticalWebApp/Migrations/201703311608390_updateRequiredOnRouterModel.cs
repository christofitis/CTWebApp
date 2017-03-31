namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequiredOnRouterModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairRouters", "CustomerFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.RepairRouters", "ProductModel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairRouters", "ProductModel", c => c.String());
            AlterColumn("dbo.RepairRouters", "CustomerFirstName", c => c.String());
        }
    }
}

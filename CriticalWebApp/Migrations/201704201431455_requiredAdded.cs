namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssemblyHouses", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssemblyHouses", "Name", c => c.String());
        }
    }
}

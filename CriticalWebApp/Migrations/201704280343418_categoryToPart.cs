namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryToPart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "Category");
        }
    }
}

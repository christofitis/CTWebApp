namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notesAssemblyHouse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssemblyHouses", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssemblyHouses", "Notes");
        }
    }
}

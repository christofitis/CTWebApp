namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Repairs", "OutSerialNumber", c => c.String());
            AddColumn("dbo.Repairs", "InProduct", c => c.String(nullable: false));
            AddColumn("dbo.Repairs", "InProductRevision", c => c.String(nullable: false));
            AddColumn("dbo.Repairs", "OutProduct", c => c.String());
            AddColumn("dbo.Repairs", "OutProductRevision", c => c.String());
            AlterColumn("dbo.Repairs", "ActionTaken", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Repairs", "ActionTaken", c => c.String());
            DropColumn("dbo.Repairs", "OutProductRevision");
            DropColumn("dbo.Repairs", "OutProduct");
            DropColumn("dbo.Repairs", "InProductRevision");
            DropColumn("dbo.Repairs", "InProduct");
            DropColumn("dbo.Repairs", "OutSerialNumber");
        }
    }
}

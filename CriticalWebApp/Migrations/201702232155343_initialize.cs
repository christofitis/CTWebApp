namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Repairs", "SerialNumberId", "dbo.SerialNumbers");
            DropIndex("dbo.Repairs", new[] { "SerialNumberId" });
            AddColumn("dbo.Repairs", "SerialNumber", c => c.String(nullable: false));
            AddColumn("dbo.Repairs", "OutSerialNumber", c => c.String());
            AddColumn("dbo.Repairs", "InProduct", c => c.String(nullable: false));
            AddColumn("dbo.Repairs", "InProductRevision", c => c.String(nullable: false));
            AddColumn("dbo.Repairs", "OutProduct", c => c.String());
            AddColumn("dbo.Repairs", "OutProductRevision", c => c.String());
            AlterColumn("dbo.Repairs", "ActionTaken", c => c.String(nullable: false));
            DropColumn("dbo.Repairs", "SerialNumberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repairs", "SerialNumberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Repairs", "ActionTaken", c => c.String());
            DropColumn("dbo.Repairs", "OutProductRevision");
            DropColumn("dbo.Repairs", "OutProduct");
            DropColumn("dbo.Repairs", "InProductRevision");
            DropColumn("dbo.Repairs", "InProduct");
            DropColumn("dbo.Repairs", "OutSerialNumber");
            DropColumn("dbo.Repairs", "SerialNumber");
            CreateIndex("dbo.Repairs", "SerialNumberId");
            AddForeignKey("dbo.Repairs", "SerialNumberId", "dbo.SerialNumbers", "Id", cascadeDelete: true);
        }
    }
}

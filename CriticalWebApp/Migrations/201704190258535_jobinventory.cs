namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobinventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartId = c.Int(nullable: false),
                        OffsiteJobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OffsiteJobs", t => t.OffsiteJobId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId)
                .Index(t => t.OffsiteJobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobInventories", "PartId", "dbo.Parts");
            DropForeignKey("dbo.JobInventories", "OffsiteJobId", "dbo.OffsiteJobs");
            DropIndex("dbo.JobInventories", new[] { "OffsiteJobId" });
            DropIndex("dbo.JobInventories", new[] { "PartId" });
            DropTable("dbo.JobInventories");
        }
    }
}

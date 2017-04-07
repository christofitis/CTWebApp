namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeProductReceived : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductReceiveds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceivedDate = c.DateTime(nullable: false),
                        Employee = c.String(),
                        NumberOfBoxes = c.Int(nullable: false),
                        QuantityOnBox = c.Int(nullable: false),
                        CountedQuantity = c.Int(nullable: false),
                        ReferenceNumber = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductReceiveds");
        }
    }
}

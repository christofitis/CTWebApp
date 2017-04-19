namespace CriticalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class perQtyPerProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductAssemblies", "QuantityPerProduct", c => c.Int(nullable: false));
            DropColumn("dbo.ProductAssemblies", "PartPerProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductAssemblies", "PartPerProduct", c => c.Int(nullable: false));
            DropColumn("dbo.ProductAssemblies", "QuantityPerProduct");
        }
    }
}

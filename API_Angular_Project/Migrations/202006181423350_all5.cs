namespace API_Angular_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "QuantityPerUnit", c => c.Int());
            AlterColumn("dbo.Products", "NeedQuantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "NeedQuantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "QuantityPerUnit", c => c.Int(nullable: false));
        }
    }
}

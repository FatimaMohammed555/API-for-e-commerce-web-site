namespace API_Angular_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aya123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalOrderPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Discount", c => c.Double());
            DropColumn("dbo.Products", "NeedQuantity");
            DropColumn("dbo.OrderDetails", "OrderNumber");
            DropColumn("dbo.OrderDetails", "TotalPrice");
            DropColumn("dbo.OrderDetails", "Discount");
            DropColumn("dbo.Orders", "OrderNumber");
            DropColumn("dbo.Orders", "OrderImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderImage", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "OrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Discount", c => c.Double());
            AddColumn("dbo.OrderDetails", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "NeedQuantity", c => c.Int());
            DropColumn("dbo.Orders", "Discount");
            DropColumn("dbo.Orders", "TotalOrderPrice");
        }
    }
}

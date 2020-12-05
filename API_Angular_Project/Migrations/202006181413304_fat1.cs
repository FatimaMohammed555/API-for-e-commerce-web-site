namespace API_Angular_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fat1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NeedQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "NeedQuantity");
        }
    }
}

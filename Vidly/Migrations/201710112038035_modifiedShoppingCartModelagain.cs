namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedShoppingCartModelagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "Customer_Id" });
            AddColumn("dbo.ShoppingCarts", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "User_Id");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.ShoppingCarts", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "Customer_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropColumn("dbo.ShoppingCarts", "User_Id");
            CreateIndex("dbo.ShoppingCarts", "Customer_Id");
            AddForeignKey("dbo.ShoppingCarts", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}

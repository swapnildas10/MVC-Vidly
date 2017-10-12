namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "FK_dbo.Rentals_dbo.AspNetUsers_ApplicationUser_Id");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUser_Id" });
             AddColumn("dbo.ShoppingCarts", "Customer_Id", c => c.Int(nullable: false));
             CreateIndex("dbo.ShoppingCarts", "Customer_Id");
             AddForeignKey("dbo.ShoppingCarts", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.ShoppingCarts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ShoppingCarts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "Customer_Id" });
             DropColumn("dbo.ShoppingCarts", "Customer_Id");
             CreateIndex("dbo.ShoppingCarts", "ApplicationUser_Id");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

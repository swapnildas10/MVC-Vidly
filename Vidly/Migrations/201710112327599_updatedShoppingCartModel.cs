namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            AddColumn("dbo.ShoppingCarts", "User", c => c.String(nullable: false));
            DropColumn("dbo.ShoppingCarts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.ShoppingCarts", "User");
            CreateIndex("dbo.ShoppingCarts", "User_Id");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

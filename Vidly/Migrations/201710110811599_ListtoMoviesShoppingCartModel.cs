namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListtoMoviesShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.ShoppingCarts", new[] { "Movie_Id" });
            DropColumn("dbo.ShoppingCarts", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "Movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "Movie_Id");
            AddForeignKey("dbo.ShoppingCarts", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}

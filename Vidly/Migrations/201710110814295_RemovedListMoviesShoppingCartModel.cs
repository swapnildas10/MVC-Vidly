namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedListMoviesShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "Movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "Movie_Id");
            AddForeignKey("dbo.ShoppingCarts", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.ShoppingCarts", new[] { "Movie_Id" });
            DropColumn("dbo.ShoppingCarts", "Movie_Id");
        }
    }
}

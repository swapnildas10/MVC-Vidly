namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIsOwnedValueFromFavoriteMoviesViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FavoriteMovies", "isOwned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FavoriteMovies", "isOwned", c => c.Boolean(nullable: false));
        }
    }
}

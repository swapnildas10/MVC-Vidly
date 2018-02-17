namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoriteMovieIsOwned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoriteMovies", "isOwned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FavoriteMovies", "isOwned");
        }
    }
}

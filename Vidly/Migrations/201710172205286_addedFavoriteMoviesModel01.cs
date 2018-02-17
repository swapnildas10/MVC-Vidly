namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFavoriteMoviesModel01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteMovies", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.FavoriteMovies", new[] { "Movie_Id" });
            DropTable("dbo.FavoriteMovies");
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSavedMovieModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedMovies",
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
            DropForeignKey("dbo.SavedMovies", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.SavedMovies", new[] { "Movie_Id" });
            DropTable("dbo.SavedMovies");
        }
    }
}

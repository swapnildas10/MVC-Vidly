namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieDbToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Poster_Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieDescriptions", "Poster_Path");
        }
    }
}

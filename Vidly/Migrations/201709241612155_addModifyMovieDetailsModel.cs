namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModifyMovieDetailsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Adult", c => c.Boolean(nullable: false));
            AddColumn("dbo.MovieDescriptions", "VoteAverage", c => c.Single(nullable: false));
            DropColumn("dbo.MovieDescriptions", "PgRated");
            DropColumn("dbo.MovieDescriptions", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieDescriptions", "Rating", c => c.Single(nullable: false));
            AddColumn("dbo.MovieDescriptions", "PgRated", c => c.Boolean(nullable: false));
            DropColumn("dbo.MovieDescriptions", "VoteAverage");
            DropColumn("dbo.MovieDescriptions", "Adult");
        }
    }
}

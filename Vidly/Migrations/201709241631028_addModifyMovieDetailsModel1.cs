namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModifyMovieDetailsModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Release_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieDescriptions", "Vote_Average", c => c.Single(nullable: false));
            AddColumn("dbo.MovieDescriptions", "Vote_Count", c => c.Int(nullable: false));
            DropColumn("dbo.MovieDescriptions", "ReleasedDate");
            DropColumn("dbo.MovieDescriptions", "VoteAverage");
            DropColumn("dbo.MovieDescriptions", "VoteCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieDescriptions", "VoteCount", c => c.Int(nullable: false));
            AddColumn("dbo.MovieDescriptions", "VoteAverage", c => c.Single(nullable: false));
            AddColumn("dbo.MovieDescriptions", "ReleasedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.MovieDescriptions", "Vote_Count");
            DropColumn("dbo.MovieDescriptions", "Vote_Average");
            DropColumn("dbo.MovieDescriptions", "Release_Date");
        }
    }
}

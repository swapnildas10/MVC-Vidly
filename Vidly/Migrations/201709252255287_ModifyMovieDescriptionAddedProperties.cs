namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieDescriptionAddedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Popularity", c => c.Single(nullable: false));
            AddColumn("dbo.MovieDescriptions", "Budget", c => c.Double(nullable: false));
            AddColumn("dbo.MovieDescriptions", "Tagline", c => c.String());
            AlterColumn("dbo.MovieDescriptions", "Vote_Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieDescriptions", "Vote_Count", c => c.Long(nullable: false));
            DropColumn("dbo.MovieDescriptions", "Tagline");
            DropColumn("dbo.MovieDescriptions", "Budget");
            DropColumn("dbo.MovieDescriptions", "Popularity");
        }
    }
}

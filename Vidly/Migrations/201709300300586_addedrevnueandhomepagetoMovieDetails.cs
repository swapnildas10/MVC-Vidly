namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrevnueandhomepagetoMovieDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Revenue", c => c.Int(nullable: false));
            AddColumn("dbo.MovieDescriptions", "Homepage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieDescriptions", "Homepage");
            DropColumn("dbo.MovieDescriptions", "Revenue");
        }
    }
}

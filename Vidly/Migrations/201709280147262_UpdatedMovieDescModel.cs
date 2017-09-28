namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMovieDescModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieDescriptions", "Title");
        }
    }
}

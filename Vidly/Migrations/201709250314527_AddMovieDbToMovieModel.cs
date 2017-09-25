namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieDbToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieDb", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieDb");
        }
    }
}

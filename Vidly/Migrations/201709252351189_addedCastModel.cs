namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCastModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieDescriptions", "Imdb_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieDescriptions", "Imdb_Id");
        }
    }
}

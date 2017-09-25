namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExtraModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        PgRated = c.Boolean(nullable: false),
                        Overview = c.String(nullable: false),
                        ReleasedDate = c.DateTime(nullable: false),
                        RunTime = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        VoteCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieDescriptions", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieDescriptions", new[] { "MovieId" });
            DropTable("dbo.MovieDescriptions");
        }
    }
}

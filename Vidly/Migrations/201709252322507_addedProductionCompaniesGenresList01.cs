namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductionCompaniesGenresList01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieDetailsGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieDescriptions", "Genres_Id", c => c.Int());
            AddColumn("dbo.MovieDescriptions", "Production_Companies_Id", c => c.Int());
            CreateIndex("dbo.MovieDescriptions", "Genres_Id");
            CreateIndex("dbo.MovieDescriptions", "Production_Companies_Id");
            AddForeignKey("dbo.MovieDescriptions", "Genres_Id", "dbo.MovieDetailsGenres", "Id");
            AddForeignKey("dbo.MovieDescriptions", "Production_Companies_Id", "dbo.ProductionCompanies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieDescriptions", "Production_Companies_Id", "dbo.ProductionCompanies");
            DropForeignKey("dbo.MovieDescriptions", "Genres_Id", "dbo.MovieDetailsGenres");
            DropIndex("dbo.MovieDescriptions", new[] { "Production_Companies_Id" });
            DropIndex("dbo.MovieDescriptions", new[] { "Genres_Id" });
            DropColumn("dbo.MovieDescriptions", "Production_Companies_Id");
            DropColumn("dbo.MovieDescriptions", "Genres_Id");
            DropTable("dbo.ProductionCompanies");
            DropTable("dbo.MovieDetailsGenres");
        }
    }
}

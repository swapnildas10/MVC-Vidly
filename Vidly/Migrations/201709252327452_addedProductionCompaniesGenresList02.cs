namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductionCompaniesGenresList02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieDescriptions", "Genres_Id", "dbo.MovieDetailsGenres");
            DropForeignKey("dbo.MovieDescriptions", "Production_Companies_Id", "dbo.ProductionCompanies");
            DropIndex("dbo.MovieDescriptions", new[] { "Genres_Id" });
            DropIndex("dbo.MovieDescriptions", new[] { "Production_Companies_Id" });
            DropColumn("dbo.MovieDescriptions", "Genres_Id");
            DropColumn("dbo.MovieDescriptions", "Production_Companies_Id");
            DropTable("dbo.MovieDetailsGenres");
            DropTable("dbo.ProductionCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieDetailsGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieDescriptions", "Production_Companies_Id", c => c.Int());
            AddColumn("dbo.MovieDescriptions", "Genres_Id", c => c.Int());
            CreateIndex("dbo.MovieDescriptions", "Production_Companies_Id");
            CreateIndex("dbo.MovieDescriptions", "Genres_Id");
            AddForeignKey("dbo.MovieDescriptions", "Production_Companies_Id", "dbo.ProductionCompanies", "Id");
            AddForeignKey("dbo.MovieDescriptions", "Genres_Id", "dbo.MovieDetailsGenres", "Id");
        }
    }
}

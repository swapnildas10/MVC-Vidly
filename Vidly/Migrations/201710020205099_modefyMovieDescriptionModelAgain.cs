namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modefyMovieDescriptionModelAgain : DbMigration
    {
        public override void Up()
        {
        //    Sql("   ALTER TABLE dbo.MovieDescriptions DROP CONSTRAINT DF__MovieDesc__Budge__74794A92 ");
        //    AlterColumn("dbo.MovieDescriptions", "Budget", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
         //   AlterColumn("dbo.MovieDescriptions", "Budget", c => c.Double(nullable: false));
        }
    }
}

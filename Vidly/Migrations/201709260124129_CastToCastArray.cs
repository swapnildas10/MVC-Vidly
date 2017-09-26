namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastToCastArray : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieCasts", "Cast_Id", c => c.Int());
            CreateIndex("dbo.MovieCasts", "Cast_Id");
            AddForeignKey("dbo.MovieCasts", "Cast_Id", "dbo.Casts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCasts", "Cast_Id", "dbo.Casts");
            DropIndex("dbo.MovieCasts", new[] { "Cast_Id" });
            DropColumn("dbo.MovieCasts", "Cast_Id");
        }
    }
}

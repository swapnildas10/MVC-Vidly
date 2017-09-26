namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastToCastArray01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCasts", "Cast_Id", "dbo.Casts");
            DropIndex("dbo.MovieCasts", new[] { "Cast_Id" });
            DropColumn("dbo.MovieCasts", "Cast_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieCasts", "Cast_Id", c => c.Int());
            CreateIndex("dbo.MovieCasts", "Cast_Id");
            AddForeignKey("dbo.MovieCasts", "Cast_Id", "dbo.Casts", "Id");
        }
    }
}

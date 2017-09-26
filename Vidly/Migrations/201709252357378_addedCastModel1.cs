namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCastModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieCasts");
        }
    }
}

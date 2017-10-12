namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedonlinerentalmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OnlineRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Movie_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlineRentals", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OnlineRentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.OnlineRentals", new[] { "User_Id" });
            DropIndex("dbo.OnlineRentals", new[] { "Movie_Id" });
            DropTable("dbo.OnlineRentals");
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedonlinerentalmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OnlineRentals", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OnlineRentals", new[] { "User_Id" });
            AddColumn("dbo.OnlineRentals", "User", c => c.String(nullable: false));
            DropColumn("dbo.OnlineRentals", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OnlineRentals", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.OnlineRentals", "User");
            CreateIndex("dbo.OnlineRentals", "User_Id");
            AddForeignKey("dbo.OnlineRentals", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

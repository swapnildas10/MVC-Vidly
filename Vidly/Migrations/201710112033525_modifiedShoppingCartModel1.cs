namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedShoppingCartModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "ApplicationUser_Id" });
           
        }
        
        public override void Down()
        {
             CreateIndex("dbo.Rentals", "ApplicationUser_Id");
            AddForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

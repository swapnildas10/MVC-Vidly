namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCurrencyToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Cost");
        }
    }
}

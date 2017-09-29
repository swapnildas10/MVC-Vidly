namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCrewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Casts", "Credit_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Casts", "Credit_Id");
        }
    }
}

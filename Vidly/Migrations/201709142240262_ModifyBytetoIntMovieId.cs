namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyBytetoIntMovieId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Movies", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Movies", "Id");
        }
    }
}

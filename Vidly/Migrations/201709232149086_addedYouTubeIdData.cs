namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedYouTubeIdData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "YoutubeId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "YoutubeId");
        }
    }
}

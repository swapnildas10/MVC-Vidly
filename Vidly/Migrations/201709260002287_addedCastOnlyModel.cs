namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCastOnlyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Character = c.String(),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Profile_Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Casts");
        }
    }
}

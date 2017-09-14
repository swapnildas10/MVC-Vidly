namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipName2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay As You Go'" +
                "WHERE DiscountRate = 0 ");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly'" +
                "WHERE DiscountRate = 10 ");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quarterly'" +
                "WHERE DiscountRate = 15 ");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Annual'" +
                "WHERE DiscountRate = 20 ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}

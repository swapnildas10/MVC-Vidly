namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'403c79b7-e4e4-4e5f-bcc5-4ca700cf1469', N'admin@vidly.com', 0, N'ADbKE3l7ZGY1TBXvDqzTpuD2DGK3HhCl788f0CkynS1biZ/4IKWiBLm+tHiWLORIIg==', N'7abbe2da-94de-4992-9b73-26b2471c9462', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b780f462-faa5-4cdb-814d-5a6f2ece62bc', N'guest@vidly.com', 0, N'AGwr18HOzyvqOZ59nUXcm7LZBPxaLCqUrhqd4yQwNu4GpL+TkYgCOwQPLeW+nbGrPQ==', N'3baa30d4-2463-4020-9e45-406cf6012f64', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'56870325-b5cb-4d3d-9b3b-4eb7f0271646', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'403c79b7-e4e4-4e5f-bcc5-4ca700cf1469', N'56870325-b5cb-4d3d-9b3b-4eb7f0271646')


");
        }
        
        public override void Down()
        {
        }
    }
}

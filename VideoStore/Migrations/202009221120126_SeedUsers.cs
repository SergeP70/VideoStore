namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cfa22388-2776-4abd-86ee-143fc0de6766', N'admin@videostore.com', 0, N'ABND4GonnrQWjAqtqtKAQ1OJHQS1Bvu2QNwYYsTJvq8gkas0HYg2JS4lGkvqPjTyCw==', N'193fbcf5-7962-4237-8299-e7b793bbe579', NULL, 0, 0, NULL, 1, 0, N'admin@videostore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f0247b47-0c51-4d54-8de9-d7f5456d56d2', N'guest@videostore.com', 0, N'AN/69NuUSN/itBcwm2F+4QnzDZ2MJ8vZA6QoOrqyu4f+aS160Jy+Af1L7cq2oOe62A==', N'3d96759d-2d24-4ffe-812a-fea3ad47f8d6', NULL, 0, 0, NULL, 1, 0, N'guest@videostore.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dea6c14a-ca5c-4098-91bb-d3edfd654b4d', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfa22388-2776-4abd-86ee-143fc0de6766', N'dea6c14a-ca5c-4098-91bb-d3edfd654b4d')

");
        }
        
        public override void Down()
        {
        }
    }
}

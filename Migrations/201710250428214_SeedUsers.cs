namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'52d1e7f6-5299-4763-981c-75597534a2b3', N'admin@vidly.com', 0, N'AGytlLYukUOXiI2Q6L/gGCRmPIULdwtZjVUCVp+imN+MNVV6IBEZVoTKpeMJ50qeaw==', N'28671d05-ee06-418b-b221-86967f0a0c77', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c69114fc-897b-4b54-a5ad-20dfac7dc2e7', N'guest@vidly.com', 0, N'AEKp8i1LeWGtVDerXy3lTyPdN8Bf6XUlx7HqJj+p29DtVnO9b8P4wJxBrFfsdObX4A==', N'e45c31e4-a825-480e-b87b-3141263660b6', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e75ef60d-b340-4144-aed6-54785a2d3990', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'52d1e7f6-5299-4763-981c-75597534a2b3', N'e75ef60d-b340-4144-aed6-54785a2d3990')

");
        }
        
        public override void Down()
        {
        }
    }
}

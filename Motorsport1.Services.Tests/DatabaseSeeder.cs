namespace Motorsport1.Services.Tests
{

    using Microsoft.AspNetCore.Identity;

    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using static Common.GeneralApplicationConstants;

    public static class DatabaseSeeder
    {

        public static Article TestArticle;
        public static ApplicationUser TestUser;
        public static Comment TestActiveComment;
        public static Comment TestInactiveComment;
        public static IdentityRole<Guid> TestPublisherRole;
        public static IdentityRole<Guid> TestAdminRole;


        public static void SeedDatabase(Motorsport1DbContext dbContext)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            TestUser = new ApplicationUser()
            {
                Id = Guid.Parse("A15AEA71-C074-4164-BF8A-01B9F3DBB497"),
                Email = "Unit@test.com",
                NormalizedEmail = "UNIT@TEST.COM",
                UserName = "Unit@test.com",
                NormalizedUserName = "UNIT@TEST.COM",
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Unit",
                LastName = "Test",
            };

            TestUser.PasswordHash = passwordHasher.HashPassword(TestUser, "123456");

            dbContext.Users.Add(TestUser);

            TestArticle = new Article()
            {
                Id = 12345678,
                Title = "Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article",
                Information = "Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test ArticleTest Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article Test Article",
                ImageUrl = "https://media.formula1.com/image/upload/f_auto/q_auto/v1688394388/fom-website/2023/Austria/albon-austria-2023-2.png.transform/9col/image.png",
                CategoryId = 2,
                IsActive = true,
                PublisherId = Guid.Parse("A15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            dbContext.Articles.Add(TestArticle);

            TestActiveComment = new Comment()
            {
                Id = 12345676,
                Content = "It was a great test!",
                ArticleId = 12345678,
                IsActive = true,
                PublisherId = Guid.Parse("A15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            TestInactiveComment = new Comment()
            {
                Id = 12345677,
                Content = "It was a great test also!",
                ArticleId = 12345678,
                IsActive = false,
                PublisherId = Guid.Parse("A15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            dbContext.Comments.Add(TestActiveComment);
            dbContext.Comments.Add(TestInactiveComment);

            TestPublisherRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("880E11C2-2254-4018-70E7-08DB94E017A9"),
                Name = PublisherRoleName,
                NormalizedName = PublisherRoleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString("D")
            };

            TestAdminRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("990E11C2-2254-4018-70E7-08DB94E017A9"),
                Name = AdminRoleName,
                NormalizedName = AdminRoleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString("D")
            };

            dbContext.Roles.Add(TestPublisherRole);
            dbContext.Roles.Add(TestAdminRole);

            dbContext.SaveChanges();
        }
    }
}

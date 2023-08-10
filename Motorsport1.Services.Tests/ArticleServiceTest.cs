namespace Motorsport1.Services.Tests
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using static DatabaseSeeder;
    using Motorsport1.Data.Models;

    public class ArticleServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
    new DbContextOptionsBuilder<Motorsport1DbContext>()
        .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
        .Options;

        private Motorsport1DbContext Context;

        private IArticleService articleService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            SeedDatabase(this.Context);

            this.articleService = new ArticleService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task DeleteAsyncShouldSucceed()
        {
            var articlesCountBefore = this.Context.Articles
                .Where(a => a.IsActive == true)
                .Count();

            int id = TestArticle.Id;

            await this.articleService.DeleteAsync(id);

            var articlesCountAfter = this.Context.Articles
                .Where(a => a.IsActive == true)
                .Count();

            Assert.That(articlesCountBefore, Is.EqualTo(articlesCountAfter + 1));

            var article = this.Context.Articles
                .First(a => a.Id == TestArticle.Id);

            article.IsActive = true;

            Context.SaveChanges();
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnTrue()
        {
            bool exist = await this.articleService.ExistByIdAsync(TestArticle.Id);

            Assert.True(exist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnFalse()
        {
            bool exist = await this.articleService.ExistByIdAsync(-1);

            Assert.False(exist);
        }

        [Test]
        public async Task IsArticleLikedAsyncShouldReturnTrue()
        {
            var articleLike = new LikedArticle
            {
                ArticleId = TestArticle.Id,
                UserId = TestUser.Id,
            };

            Context.LikedArticles.Add(articleLike);

            Context.SaveChanges();

            bool liked = await this.articleService.IsArticleLikedAsync(TestArticle.Id, TestUser.Id.ToString());

            Assert.True(liked);

            var likedArticle = Context.LikedArticles
                .First(la => la.ArticleId == TestArticle.Id && la.UserId == TestUser.Id);

            Context.LikedArticles.Remove(likedArticle);

            Context.SaveChanges();
        }

        [Test]
        public async Task IsArticleLikedAsyncShouldReturnFalse()
        {
            bool liked = await this.articleService.IsArticleLikedAsync(TestArticle.Id, TestUser.Id.ToString());

            Assert.False(liked);
        }

        [Test]
        public async Task IsUserOwnerOfArticleAsyncShouldReturnTrue()
        {
            bool isOwner = await this.articleService.IsUserOwnerOfArticleAsync(TestArticle.Id, TestUser.Id.ToString());

            Assert.True(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfArticleAsyncShouldReturnFalse()
        {
            bool isOwner = await this.articleService.IsUserOwnerOfArticleAsync(TestArticle.Id, "0DE4C685-3EA5-4F74-B54B-8464457A7E02");

            Assert.False(isOwner);
        }

        [Test]
        public async Task LikeArticleAsyncShouldSucceed()
        {
            await this.articleService.LikeArticleAsync(TestArticle.Id, TestUser.Id.ToString());

            var isLiked = this.Context.LikedArticles
                .Any(la => la.UserId == TestUser.Id && la.ArticleId == TestArticle.Id);

            Assert.True(isLiked);

            var likedArticle = this.Context.LikedArticles
                .First(la => la.UserId == TestUser.Id && la.ArticleId == TestArticle.Id);

            Context.LikedArticles.Remove(likedArticle);

            Context.SaveChanges();
        }

        [Test]
        public async Task LikeArticleAsyncShouldSucceedAndIncreeseLikes()
        {
            var articleLikesBefore = this.Context.Articles
                .Where(a => a.Id == TestArticle.Id)
                .Select(a => a.Likes)
                .First();

            await this.articleService.LikeArticleAsync(TestArticle.Id, TestUser.Id.ToString());

            var articleLikesAfter = this.Context.Articles
                .Where(a => a.Id == TestArticle.Id)
                .Select(a => a.Likes)
                .First();

            Assert.That(articleLikesBefore, Is.EqualTo(articleLikesAfter - 1));

            var likedArticle = this.Context.LikedArticles
                .First(la => la.UserId == TestUser.Id && la.ArticleId == TestArticle.Id);

            Context.LikedArticles.Remove(likedArticle);

            Context.SaveChanges();
        }
    }
}

namespace Motorsport1.Services.Tests
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using static DatabaseSeeder;

    public class CommentServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext Context;

        private ICommentService commentService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            SeedDatabase(this.Context);

            this.commentService = new CommentService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task DeleteAsyncShouldSucceed()
        {

            var commentsCountBefore = this.Context.Comments
                .Where(c => c.ArticleId == TestArticle.Id && c.IsActive == true)
                .Count();

            await this.commentService.DeleteAsync(TestActiveComment.Id);

            var commentsCountAfter = this.Context.Comments
                .Where(c => c.ArticleId == TestArticle.Id && c.IsActive == true)
                .Count();

            Assert.That(commentsCountAfter, Is.EqualTo(commentsCountBefore - 1));

            var comment = Context.Comments.Find(TestActiveComment.Id);

            comment.IsActive = true;

            Context.SaveChanges();
        }

        [Test]
        public async Task DeleteAsyncShouldReturnArticleId()
        {
            int articleId = await this.commentService.DeleteAsync(TestActiveComment.Id);

            Assert.That(articleId, Is.EqualTo(TestArticle.Id));

            var comment = Context.Comments.Find(TestActiveComment.Id);

            comment.IsActive = true;

            Context.SaveChanges();
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnTrue()
        {
            bool exist = await this.commentService.ExistByIdAsync(TestActiveComment.Id);

            Assert.True(exist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnFalseWithInactiveComment()
        {
            bool exist = await this.commentService.ExistByIdAsync(TestInactiveComment.Id);

            Assert.False(exist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnFalseWithEnexistingComment()
        {
            bool exist = await this.commentService.ExistByIdAsync(999999999);

            Assert.False(exist);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnTrue()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(TestActiveComment.Id, TestUser.Id.ToString());

            Assert.True(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnFalseBecauseOfInactiveComment()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(TestInactiveComment.Id, TestUser.Id.ToString());

            Assert.False(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnFalseBecauseOfWrongUser()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(TestActiveComment.Id, "0DE4C685-3EA5-4F74-B54B-8464457A7E02");

            Assert.False(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnFalseBecauseOfWrongUserAndInactiveComment()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(TestInactiveComment.Id, "0DE4C685-3EA5-4F74-B54B-8464457A7E02");

            Assert.False(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnFalseBecauseOfUnExistingComment()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(999999999, TestUser.Id.ToString());

            Assert.False(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfCommentAsyncShouldReturnFalseBecauseOfWrongUserAndExistingComment()
        {
            bool isOwner = await this.commentService.IsUserOwnerOfCommentAsync(999999999, "0DE4C685-3EA5-4F74-B54B-8464457A7E02");

            Assert.False(isOwner);
        }
    }
}

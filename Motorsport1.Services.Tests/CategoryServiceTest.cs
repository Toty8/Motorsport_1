using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Services.Data.Interfaces;
using Motorsport1.Services.Data;

namespace Motorsport1.Services.Tests
{
    public class CategoryServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext Context;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            this.categoryService = new CategoryService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllNamesAsyncShouldSucced()
        {
            int categoryCount = this.Context.Categories.Count();

            var categoryNames = await this.categoryService.AllNamesAsync();

            Assert.That(categoryNames.Count(), Is.EqualTo(categoryCount));
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnTrue()
        {
            var categoryId = this.Context.Categories
                .Select(c => c.Id)
                .OrderBy(c => c)
                .First();

            var categoryExist = await this.categoryService.ExistByIdAsync(categoryId);

            Assert.True(categoryExist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnFalse()
        {
            var categoryExist = await this.categoryService.ExistByIdAsync(1000000);

            Assert.False(categoryExist);
        }
    }
}

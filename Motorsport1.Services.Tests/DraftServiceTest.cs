namespace Motorsport1.Services.Tests
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using static DatabaseSeeder;
    using static Common.GeneralApplicationConstants;

    public class DraftServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext Context;

        private IDraftService draftService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            SeedDatabase(this.Context);

            this.draftService = new DraftService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetBudgetLeftAsyncShouldSucceed()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.BirthDate)
                .Select(d => new
                {
                    d.Id,
                    d.Price
                })
                .First();

            TestUser.DriverId = driver.Id;

            Context.SaveChanges();

            decimal budgetLeft = await this.draftService.GetBudgetLeftAsync(TestUser.Id.ToString());

            Assert.That(budgetLeft, Is.EqualTo(DraftBudget-driver.Price));

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task IsThereSelectedDriverAsyncShouldReturnTrue()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.BirthDate)
                .Select(d => new
                {
                    d.Id,
                    d.Price
                })
                .First();

            TestUser.DriverId = driver.Id;

            Context.SaveChanges();

            bool isThereSelectedDriver = await this.draftService.IsThereSelectedDriverAsync(TestUser.Id.ToString());

            Assert.True(isThereSelectedDriver);

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task IsThereSelectedDriverAsyncShouldReturnFalse()
        {
            bool isThereSelectedDriver = await this.draftService.IsThereSelectedDriverAsync(TestUser.Id.ToString());

            Assert.False(isThereSelectedDriver);
        }

        [Test]
        public async Task IsThereSelectedDriverAsyncShouldReturnFalseBecauseOfUnExistingUser()
        {
            bool isThereSelectedDriver = await this.draftService.IsThereSelectedDriverAsync("Very Unexisting User");

            Assert.False(isThereSelectedDriver);
        }
    }
}

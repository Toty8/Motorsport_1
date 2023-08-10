namespace Motorsport1.Services.Tests
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using static DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using NUnit.Framework.Internal;

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

        [Test]
        public async Task IsUserDraftedAsyncShouldReturnTrue()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.BirthDate)
                .Select(d => new
                {
                    d.Id,
                    d.Price,
                    d.TeamId
                })
                .First();

            TestUser.DriverId = driver.Id;
            TestUser.TeamId = driver.TeamId;

            Context.SaveChanges();

            bool isUserDrafted = await this.draftService.IsUserDraftedAsync(TestUser.Id.ToString());

            Assert.True(isUserDrafted);

            TestUser.DriverId = null;
            TestUser.TeamId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task IsUserDraftedAsyncShouldReturnFalse()
        {
            bool isUserDrafted = await this.draftService.IsUserDraftedAsync(TestUser.Id.ToString());

            Assert.False(isUserDrafted);
        }

        [Test]
        public async Task IsUserDraftedAsyncShouldReturnFalseBecauseUserHaveOnlyADriver()
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

            bool isUserDrafted = await this.draftService.IsUserDraftedAsync(TestUser.Id.ToString());

            Assert.False(isUserDrafted);

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task IsUserDraftedAsyncShouldReturnFalseBecauseOfUnExistingUser()
        {
            bool isUserDrafted = await this.draftService.IsUserDraftedAsync("Very Unexisting User");

            Assert.False(isUserDrafted);
        }

        [Test]
        public async Task SelectDriverAsyncShouldSucceed()
        {
            var driverId = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.BirthDate)
                .Select(d => d.Id)
                .First();

            await draftService.SelectDriverAsync(driverId, TestUser.Id.ToString());

            Assert.That(TestUser.DriverId, Is.EqualTo(driverId));

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task SelectDriverAsyncShouldSucceedWithAlreadySelectedDriver()
        {
            var driverIdBefore = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.BirthDate)
                .Select(d => d.Id)
                .First();

            await draftService.SelectDriverAsync(driverIdBefore, TestUser.Id.ToString());

            var driverIdAfter = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.BirthDate)
                .Select(d => d.Id)
                .First();

            await draftService.SelectDriverAsync(driverIdAfter, TestUser.Id.ToString());

            Assert.That(TestUser.DriverId, Is.EqualTo(driverIdAfter));

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task SelectDriverAsyncShouldFailBecauseSetingUnexistingDriver()
        {
            await draftService.SelectDriverAsync(99999999, TestUser.Id.ToString());

            Assert.That(TestUser.DriverId, Is.EqualTo(99999999));

            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task SelectTeamAsyncShouldSucceed()
        {
            var teamId = this.Context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(t => t.TotalPoints)
                .Select(t => t.Id)
                .First();

            await draftService.SelectTeamAsync(teamId, TestUser.Id.ToString());

            Assert.That(TestUser.TeamId, Is.EqualTo(teamId));

            TestUser.TeamId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task SelectTeamAsyncShouldSucceedWithAlreadySelectedDriver()
        {
            var driverId = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.BirthDate)
                .Select(d => d.Id)
                .First();

            await draftService.SelectDriverAsync(driverId, TestUser.Id.ToString());

            var teamId = this.Context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.TotalPoints)
                .Select(t => t.Id)
                .First();

            await draftService.SelectTeamAsync(teamId, TestUser.Id.ToString());

            Assert.That(TestUser.TeamId, Is.EqualTo(teamId));
            Assert.That(TestUser.DriverId, Is.EqualTo(driverId));

            TestUser.TeamId = null;
            TestUser.DriverId = null;

            Context.SaveChanges();
        }

        [Test]
        public async Task SelectTeamAsyncShouldFailBecauseSetingUnexistingTeam()
        {

            await draftService.SelectTeamAsync(99999999, TestUser.Id.ToString());

            Assert.That(TestUser.TeamId, Is.EqualTo(99999999));

            TestUser.TeamId = null;

            Context.SaveChanges();
        }
    }
}

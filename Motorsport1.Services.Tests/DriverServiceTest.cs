namespace Motorsport1.Services.Tests
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    using Motorsport1.Data;
    using Motorsport1.Services.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Web.ViewModels.Driver;
    using static DatabaseSeeder;
    using static Common.GeneralApplicationConstants;

    public class DriverServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions = 
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext Context;

        private IDriverService driverService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            this.driverService = new DriverService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task DoesTeamHaveFreeSeatAsyncShouldReturnTrue()
        {
            bool result = await this.driverService.DoesTeamHaveFreeSeatAsync(100000000);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DoesTeamHaveFreeSeatAsyncShouldReturnFalse()
        {
            int teamId = this.Context.Teams
                .Where(t => t.Drivers.Count() == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .Select(t => t.Id)
                .First();

            bool result = await this.driverService.DoesTeamHaveFreeSeatAsync(teamId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DeleteAsyncShouldSucceed()
        {

            var driverId = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Points)
                .Select(d => d.Id)
                .First();

            var countBefore = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                   .Count();

            await this.driverService.DeleteAsync(driverId);

            var countAfter = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .Count();

            Assert.That(countBefore, Is.EqualTo(countAfter + 2));

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }


        [Test]
        public async Task EditDraftPriceAsyncShouldSucceed()
        {
            var driverId = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Points)
                .Select(d => d.Id)
                .First();

            var getPriceBefore = this.Context.Drivers
                .Where(d => d.Id == driverId)
                .Select(d => d.Price)
                .First();

            await this.driverService.EditDraftPriceAsync(-1M, driverId);

            var getPriceAfter = this.Context.Drivers
                .Where(d => d.Id == driverId)
                .Select(d => d.Price)
                .First();

            Assert.That(getPriceAfter, Is.EqualTo(-1M));

            await this.driverService.EditDraftPriceAsync(getPriceBefore, driverId);
        }
    }
}
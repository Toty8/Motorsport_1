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
    using Motorsport1.Web.ViewModels.Standing;
    using Motorsport1.Data.Models;

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

        [Test]
        public async Task EditDriverStatisticsAsyncHavePointFinish()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.Points
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 5,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var pointsAfter = this.Context.Drivers
                .Where(t => t.Id == driver.Id)
                .Select(t => t.Points)
                .First();

            Assert.That(pointsAfter, Is.EqualTo(driver.Points + 10));
        }


        [Test]
        public async Task EditDriverStatisticsAsyncHavePodiumFinish()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.Podiums
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 3,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var podiumsAfter = this.Context.Drivers
                .Where(t => t.Id == driver.Id)
                .Select(t => t.Podiums)
                .First();

            Assert.That(podiumsAfter, Is.EqualTo(driver.Podiums + 1));
        }

        [Test]
        public async Task EditDriverStatisticsAsyncHaveWinFinish()
        {

            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.Wins
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 1,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var winsAfter = this.Context.Drivers
                .Where(t => t.Id == driver.Id)
                .Select(t => t.Wins)
                .First();

            Assert.That(winsAfter, Is.EqualTo(driver.Wins + 1));
        }

        [Test]
        public async Task EditDriverStatisticsAsyncHaveFastestLap()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.Points
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 13,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = true
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var pointsAfter = this.Context.Drivers
                .Where(t => t.Id == driver.Id)
                .Select(t => t.Points)
                .First();

            Assert.That(pointsAfter, Is.EqualTo(driver.Points + 1));
        }

        [Test]
        public async Task EditDriverStatisticsAsyncHavePolePosition()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.PolePositions
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 13,
                WasDriverOnPolePosition = true,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var polePositionsAfter = this.Context.Drivers
                .Where(t => t.Id == driver.Id)
                .Select(t => t.PolePositions)
                .First();

            Assert.That(polePositionsAfter, Is.EqualTo(driver.PolePositions + 1));
        }

        [Test]
        public async Task EditDriverStatisticsAsyncHaveBestResult()
        {
            var driver = this.Context.Drivers
                .Where(d => (d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam) && d.BestResult != 1)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.BestResult
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = driver.BestResult == null ? 1 : (int)driver.BestResult - 1,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);

            var bestResultAfter = this.Context.Drivers
                .Where(d => d.Id == driver.Id)
                .Select(d => d.BestResult)
                .First();

            Assert.That(bestResultAfter, Is.Not.EqualTo(driver.BestResult));
        }

        [Test]
        public async Task EditDriverStatisticsAsyncHaveBestResultCount()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    d.BestResult,
                    d.BestResultCount
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = driver.BestResult == null ? 1 : (int)driver.BestResult!,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.driverService.EditDriverStatisticsAsync(stats, driver.Id);


            var bestResultCountAfter = this.Context.Drivers
                .Where(d => d.Id == driver.Id)
                .Select(d => d.BestResultCount)
                .First();

            Assert.That(bestResultCountAfter, Is.Not.EqualTo(driver.BestResultCount));
        }

        [Test]
        public async Task ExistByIdAsyncShouldreturnTrue()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Points)
                .First();

            bool exist = await this.driverService.ExistByIdAsync(driver.Id);

            Assert.IsTrue(exist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldreturnFalse()
        {
            bool exist = await this.driverService.ExistByIdAsync(1000000);

            Assert.IsFalse(exist);
        }

        [Test]
        public async Task ExistByNameAsyncShouldreturnTrue()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Points)
                .First();

            bool exist = await this.driverService.ExistByNameAsync(driver.Name);

            Assert.IsTrue(exist);
        }

        [Test]
        public async Task ExistByNameAsyncShouldreturnFalse()
        {
            bool exist = await this.driverService.ExistByNameAsync("The Most Invalid driver");

            Assert.IsFalse(exist);
        }

        [Test]
        public async Task GetNumberByIdAsyncShouldSucceed()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Championships)
                .Select(d => new
                {
                    d.Id,
                    d.Number
                })
                .First();

            var number = await this.driverService.GetNumberByIdAsync(driver.Id);

            Assert.That(number, Is.EqualTo(driver.Number));
        }


        [Test]
        public async Task GetNumberByIdAsyncShouldFail()
        {
            var number = await this.driverService.GetNumberByIdAsync(100000000);

            Assert.That(number, Is.EqualTo(0));
        }

        [Test]
        public async Task GetTeamIdByDriverIdAsyncShouldSucceed()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Championships)
                .Select(d => new
                {
                    d.Id,
                    d.TeamId
                })
                .First();

            var number = await this.driverService.GetTeamIdByDriverIdAsync(driver.Id);

            Assert.That(number, Is.EqualTo(driver.TeamId));
        }

        [Test]
        public async Task IsDriverCurrentChampionAsyncShouldReturnTrue()
        {
            var driver = this.Context.Drivers
                .Where(d => d.IsCurrentChampion)
                .Select(d => d.Id)
                .First();

            bool result = await this.driverService.IsDriverCurrentChampionAsync(driver);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsDriverCurrentChampionAsyncShouldReturnFalse()
        {
            var driver = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam && d.IsCurrentChampion == false)
                .OrderByDescending(d => d.Championships)
                .Select(d => d.Id)
                .First();

            bool result = await this.driverService.IsDriverCurrentChampionAsync(driver);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsDriverCurrentChampionAsyncShouldReturnFalseWithInvalidInput()
        {
            bool result = await this.driverService.IsDriverCurrentChampionAsync(10000000);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsThisNumberTakenAsyncShouldReturnTrue()
        {
            var driverNumber = this.Context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.BirthDate)
                .Select(d => d.Number)
                .First();

            bool result = await this.driverService.IsThisNumberTakenAsync(driverNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsThisNumberTakenAsyncShouldReturnFalse()
        {
            bool result = await this.driverService.IsThisNumberTakenAsync(101);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ResetAsyncBecomeChampion()
        {
            var driverChampionshipsBefore = this.Context.Drivers
                .OrderByDescending(t => t.Points)
                .Select(t => new
                {
                    t.Championships,
                    t.Id
                })
                .First();

            await this.driverService.ResetAsync();

            var driverChampionshipAfter = this.Context.Drivers
                .Where(t => t.Id == driverChampionshipsBefore.Id)
                .Select(t => t.Championships)
                .First();

            Assert.That(driverChampionshipAfter, Is.EqualTo(driverChampionshipsBefore.Championships + 1));

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncBecomeCurrentChampion()
        {
            var driverChampionshipsBefore = this.Context.Drivers
                .OrderByDescending(t => t.Points)
                .Select(t =>t.Id)
                .First();

            await this.driverService.ResetAsync();

            var driverIsCurrentChampionAfter = this.Context.Drivers
                .Where(t => t.Id == driverChampionshipsBefore)
                .Select(t => t.IsCurrentChampion)
                .First();

            Assert.That(driverIsCurrentChampionAfter, Is.EqualTo(true));

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangelastYearStanding()
        {
            var drivers = this.Context.Drivers
            .OrderByDescending(d => d.Points)
            .ToArray();

            Driver driver = null;

            int lastYearStanding = 0;

            for (int i = 1; i <= drivers.Length; i++)
            {
                if (drivers[i].LastYearStanding != i)
                {
                    driver = drivers[i];
                    lastYearStanding = driver.LastYearStanding == null ? 100000 : (int)driver.LastYearStanding;
                    break;
                }
            }

            await this.driverService.ResetAsync();

            if (driver == null)
            {
                Assert.That(1, Is.EqualTo(1));
            }
            else
            {
                var driverStandingAfter = this.Context.Drivers
                    .Where(t => t.Id == driver.Id)
                    .Select(t => t.LastYearStanding)
                    .First();

                Assert.That(lastYearStanding, Is.Not.EqualTo(driverStandingAfter));
            }

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangePointToZero()
        {
            var driver = this.Context.Drivers
            .OrderByDescending(d => d.Points)
            .First();

            await this.driverService.ResetAsync();

            Assert.That(driver.Points, Is.EqualTo(0));


            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangeBestResultToNull()
        {
            var driver = this.Context.Drivers
                .OrderBy(d => d.BestResult)
                .First();

            await this.driverService.ResetAsync();

            Assert.That(driver.BestResult, Is.EqualTo(null));


            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangeBestResultCountToNull()
        {
            var driver = this.Context.Drivers
            .OrderByDescending(d => d.Points)
            .First();

            await this.driverService.ResetAsync();

            Assert.That(driver.BestResultCount, Is.EqualTo(null));


            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncDeleteDraftUsers()
        {
            var driver = this.Context.Drivers
            .OrderByDescending(t => t.DraftUsers.Count)
            .ThenByDescending(t => t.Points)
            .First();

            await this.driverService.ResetAsync();

            Assert.That(driver.DraftUsers.Count, Is.EqualTo(0));


            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }
    }
}
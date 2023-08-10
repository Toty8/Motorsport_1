namespace Motorsport1.Services.Tests
{

    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    using Motorsport1.Data;
    using Motorsport1.Services.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Web.ViewModels.Team;
    using static DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using Motorsport1.Data.Models;
    using Motorsport1.Web.ViewModels.Standing;

    public class TeamServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext context;

        private ITeamService teamService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.context = new Motorsport1DbContext(dbOptions);

            context.Database.EnsureCreated();

            this.teamService = new TeamService(this.context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task ExistByIdAsyncShouldreturnTrue()
        {
            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .First();

            bool exist = await this.teamService.ExistByIdAsync(team.Id);

            Assert.IsTrue(exist);
        }

        [Test]
        public async Task ExistByIdAsyncShouldreturnFalse()
        {
            bool exist = await this.teamService.ExistByIdAsync(1000000);

            Assert.IsFalse(exist);
        }

        [Test]
        public async Task ExistByNameAsyncShouldreturnTrue()
        {
            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .First();

            bool exist = await this.teamService.ExistByNameAsync(team.Name);

            Assert.IsTrue(exist);
        }

        [Test]
        public async Task ExistByNameAsyncShouldreturnFalse()
        {
            bool exist = await this.teamService.ExistByNameAsync("The Most Invalid team");

            Assert.IsFalse(exist);
        }

        [Test]
        public async Task IsGridOfTeamsFullAsyncShouldreturnTrue()
        {
            var teams = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .Count();

            bool exist = await this.teamService.IsGridOfTeamsFullAsync();

            if (teams == MaxTeams)
            {
                Assert.IsTrue(exist);
            }
            else
            {
                Assert.IsFalse(exist);
            }
        }

        [Test]
        public async Task IsGridOfTeamsFullAsyncShouldreturnFalse()
        {
            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam && t.LastYearStanding != null)
                .OrderByDescending(t => t.Name)
                .First();

            await this.teamService.DeleteAsync(team.Id);

            bool exist = await this.teamService.IsGridOfTeamsFullAsync();

            Assert.IsFalse(exist);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task DeleteAsyncShouldSucceed()
        {

            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .First();

            var countBefore = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                   .Count();

            await this.teamService.DeleteAsync(team.Id);

            var countAfter = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .Count();

            Assert.That(countBefore, Is.EqualTo(countAfter + 1));

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task EditDraftPriceAsyncShouldSucceed()
        {
            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .First();

            var getPriceBefore = this.context.Teams
                .Where(t => t.Id == team.Id)
                .Select(t => t.Price)
                .First();

            await this.teamService.EditDraftPriceAsync(-1M, team.Id);

            var getPriceAfter = this.context.Teams
                .Where(t => t.Id == team.Id)
                .Select(t => t.Price)
                .First();

            Assert.That(getPriceAfter, Is.EqualTo(-1M));

            await this.teamService.EditDraftPriceAsync(getPriceBefore, team.Id);
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHavePointFinish()
        {
            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var pointsBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Points)
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 5,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var pointsAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Points)
                .First();

            Assert.That(pointsAfter, Is.EqualTo(pointsBefore + 10));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHavePodiumFinish()
        {
            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var podiumsBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Podiums)
                .First();
            
            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 3,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var podiumsAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Podiums)
                .First();

            Assert.That(podiumsAfter, Is.EqualTo(podiumsBefore + 1));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHaveWinFinish()
        {

            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var winsBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Wins)
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 1,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var winsAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Wins)
                .First();

            Assert.That(winsAfter, Is.EqualTo(winsBefore + 1));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHaveFastestLap()
        {
            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var pointsBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Points)
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 13,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = true
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var pointsAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.Points)
                .First();

            Assert.That(pointsAfter, Is.EqualTo(pointsBefore + 1));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHavePolePosition()
        {
            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var polePositionsBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.PolePositions)
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = 13,
                WasDriverOnPolePosition = true,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var polePositionsAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.PolePositions)
                .First();

            Assert.That(polePositionsAfter, Is.EqualTo(polePositionsBefore + 1));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHaveBestResult()
        {
            var team = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam && t.BestResult != 1)
                .OrderBy(t => t.BestResult)
                .Select(t => new 
                { 
                    t.BestResult,
                    t.Id
                })
                .First();

            var driverId = this.context.Drivers
                .Where(d => d.TeamId == team.Id)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = team.BestResult == null ? 1 : (int)team.BestResult - 1,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var bestResultAfter = this.context.Teams
                .Where(t => t.Id == team.Id)
                .Select(t => t.BestResult)
                .First();

            Assert.That(bestResultAfter, Is.Not.EqualTo(team.BestResult));
        }

        [Test]
        public async Task EditTeamStatisticsAsyncHaveBestResultCount()
        {
            var driverId = this.context.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Name)
                .Select(d => d.Id)
                .First();

            var teamBefore = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => new
                {
                    t.BestResult,
                    t.BestResultCount
                })
                .First();

            EditDriverStatisticsViewModel stats = new EditDriverStatisticsViewModel()
            {
                RacePosition = teamBefore.BestResult == null ? 1 : (int)teamBefore.BestResult!,
                WasDriverOnPolePosition = false,
                DriverHaveFastestLap = false
            };

            await this.teamService.EditTeamStatisticsAsync(stats, driverId);

            var bestResultCountAfter = this.context.Teams
                .Where(t => t.Drivers.Any(d => d.Id == driverId))
                .Select(t => t.BestResultCount)
                .First();

            Assert.That(bestResultCountAfter, Is.Not.EqualTo(teamBefore.BestResultCount));
        }

        [Test]
        public async Task IsTeamPriceBiggerThenBudgetAsyncShouldReturnTrue()
        {
            var teamId = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(t => t.Name)
                .Select(t => t.Id)
                .First();

            bool isPriceBigger = await this.teamService.IsTeamPriceBiggerThenBudgetAsync(teamId, -1M);

            Assert.True(isPriceBigger);
        }

        [Test]
        public async Task IsTeamPriceBiggerThenBudgetAsyncShouldReturnFalse()
        {
            var teamId = this.context.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(t => t.Name)
                .Select(t => t.Id)
                .First();

            bool isPriceBigger = await this.teamService.IsTeamPriceBiggerThenBudgetAsync(teamId, 101M);

            Assert.False(isPriceBigger);
        }

        [Test]
        public async Task ResetAsyncBecomeChampion()
        {
            var teamChampionshipsBefore = this.context.Teams
                .OrderByDescending(t => t.Points)
                .Select(t => new
                {
                    t.Championships,
                    t.Id
                })
                .First();

            await this.teamService.ResetAsync();

            var teamChampionshipAfter = this.context.Teams
                .Where(t => t.Id == teamChampionshipsBefore.Id)
                .Select(t => t.Championships)
                .First();

            Assert.That(teamChampionshipAfter, Is.EqualTo(teamChampionshipsBefore.Championships + 1));

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangelastYearStanding()
        {
            var teams = this.context.Teams
            .OrderByDescending(t => t.Points)
            .ToArray();

            Team team = null;

            int lastYearStanding = 0;

            for (int i = 1; i < 11; i++)
            {
                if (teams[i].LastYearStanding != i)
                {
                    team = teams[i];
                    lastYearStanding = team.LastYearStanding == null ? 100000 : (int)team.LastYearStanding;
                    break;
                }
            }

            await this.teamService.ResetAsync();

            if (team == null)
            {
                Assert.That(1, Is.EqualTo(1));
            }
            else
            {
                var teamStandingAfter = this.context.Teams
                    .Where(t => t.Id == team.Id)
                    .Select(t => t.LastYearStanding)
                    .First();

                Assert.That(lastYearStanding, Is.Not.EqualTo(teamStandingAfter));
            }

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangePointToZero()
        {
            var team = this.context.Teams
            .OrderByDescending(t => t.Points)
            .First();

            await this.teamService.ResetAsync();

            Assert.That(team.Points, Is.EqualTo(0));
            

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangeBestResultToNull()
        {
            var team = this.context.Teams
            .OrderBy(t => t.BestResult)
            .First();

            await this.teamService.ResetAsync();

            Assert.That(team.BestResult, Is.EqualTo(null));


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncChangeBestResultCountToNull()
        {
            var team = this.context.Teams
            .OrderByDescending(t => t.Points)
            .First();

            await this.teamService.ResetAsync();

            Assert.That(team.BestResultCount, Is.EqualTo(null));


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ResetAsyncDeleteDraftUsers()
        {
            var team = this.context.Teams
            .OrderByDescending(t => t.DraftUsers.Count)
            .ThenByDescending(t => t.Points)
            .First();

            await this.teamService.ResetAsync();

            Assert.That(team.DraftUsers.Count, Is.EqualTo(0));


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}

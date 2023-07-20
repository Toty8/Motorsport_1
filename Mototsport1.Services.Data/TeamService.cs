namespace Mototsport1.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Web.ViewModels.Standing;
    using Motorsport1.Web.ViewModels.Team;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.GeneralApplicationConstants;

    public class TeamService : ITeamService
    {
        private readonly Motorsport1DbContext dbContext;

        public TeamService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(AddTeamViewModel model)
        {
            Team team = new Team()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
            };

            await this.dbContext.Teams.AddAsync(team);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllTeamsViewModel>> AllAsync()
        {
            ICollection<AllTeamsViewModel> teams = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.LastYearStanding.HasValue)
                .ThenBy(t => t.LastYearStanding)
                .Select(t => new AllTeamsViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Drivers = t.Drivers.Select(d => d.Name).ToArray(),
                })
                .ToListAsync();

            return teams;
        }

        public async Task<IEnumerable<TeamNamesViewModel>> AllTeamsAvailableAndDriversTeamAsync(int id)
        {
            IEnumerable<TeamNamesViewModel> teams = await this.dbContext.Teams
                 .Where(t => t.Drivers.Count < MaxDriversPerTeam || t.Id == id)
                 .Select(t => new TeamNamesViewModel
                 {
                     Id = t.Id,
                     Name = t.Name,
                 })
                 .ToArrayAsync();

            return teams;
        }

        public async Task<IEnumerable<TeamNamesViewModel>> AllTeamsAvailableAsync()
        {
            IEnumerable<TeamNamesViewModel> teams = await this.dbContext.Teams
                .Where(t => t.Drivers.Count < MaxDriversPerTeam)
                .Select(t => new TeamNamesViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToArrayAsync();

            return teams;
        }

        public async Task DeleteAsync(int id)
        {
            Team team = await this.dbContext.Teams
                .Include(t => t.Drivers)
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .FirstAsync(t => t.Id == id);

            foreach (var d in team.Drivers)
            {
                d.TeamId = null;
                d.Team = null;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesTeamHaveFreeSeat(int id)
        {
            int driversCount = await this.dbContext.Teams
                .Where(t => t.Id == id)
                .Select(t => t.Drivers)
                .CountAsync();

            return driversCount < MaxDriversPerTeam;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await this.dbContext.Teams.AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await this.dbContext.Teams
                .AnyAsync(d => d.Name == name);
        }

        public async Task<TeamDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Team team = await this.dbContext.Teams
                .Include(t => t.Drivers)
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .FirstAsync(t => t.Id == id);

            return new TeamDetailsViewModel
            {
                Id = team.Id,
                Name = team.Name,
                ImageUrl = team.ImageUrl,
                Championships = team.Championships,
                Wins = team.Wins,
                PolePositions = team.PolePositions,
                Podiums = team.Podiums,
                Points = team.Points,
                TotalPoints = team.TotalPoints,
                Drivers = team.Drivers.Select(d => d.Name).ToArray()
            };
        }

        public async Task<TeamPreDeleteViewModel> GetForDeleteById(int id)
        {
            Team team = await this.dbContext.Teams
                .Include(t => t.Drivers)
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .FirstAsync(t => t.Id == id);

            string[] driverNames = team.Drivers.Select(d => d.Name).ToArray();

            return new TeamPreDeleteViewModel
            {
                Name = team.Name,
                ImageUrl = team.ImageUrl,
                Drivers = String.Join(" and ", driverNames)
            };
        }

        public async Task<bool> IsGridOfTeamsFull()
        {
            int teamsCount = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .CountAsync();

            return teamsCount == MaxTeams;
        }

        public async Task<IEnumerable<TeamStandingViewModel>> StandingAsync()
        {
            IEnumerable<TeamStandingViewModel> teams = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.BestResult.HasValue)
                .ThenBy(t => t.BestResult)
                .ThenByDescending(t => t.BestResultCount.HasValue)
                .ThenBy(t => t.BestResultCount)
                .Select(t => new TeamStandingViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Points = t.Points,
                    TeamDrivers = String.Join(" and ", t.Drivers.Select(d => d.Name).ToArray())
                }).ToArrayAsync();

            return teams;
        }
    }
}

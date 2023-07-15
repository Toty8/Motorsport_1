namespace Mototsport1.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Motorsport1.Data;
    using Motorsport1.Data.Models;
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
    }
}

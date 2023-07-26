﻿namespace Mototsport1.Services.Data
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

        public async Task EditAsync(EditTeamViewModel model, int id)
        {
            Team team = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .FirstAsync(t => t.Id == id);

            team.Name = model.Name;
            team.ImageUrl = model.ImageUrl;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditTeamStatisticsAsync(EditDriverStatisticsViewModel model, int id)
        {
            Team team = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .FirstAsync(t => t.Drivers.Any(d => d.Id == id));

            if (model.WasDriverOnPolePosition)
            {
                team.PolePositions++;
                team.Points++;
                team.TotalPoints++;
            }

            if (model.DriverHaveFastestLap)
            {
                team.Points++;
                team.TotalPoints++;
            }

            switch (model.RacePosition)
            {
                case 1:
                    team.Points += 25;
                    team.TotalPoints += 25;
                    team.Wins++;
                    team.Podiums++;
                    break;

                case 2:
                    team.Points += 18;
                    team.TotalPoints += 18;
                    team.Podiums++;
                    break;

                case 3:
                    team.Points += 15;
                    team.TotalPoints += 15;
                    team.Podiums++;
                    break;

                case 4:
                    team.Points += 12;
                    team.TotalPoints += 12;
                    break;

                case 5:
                    team.Points += 10;
                    team.TotalPoints += 10;
                    break;

                case 6:
                    team.Points += 8;
                    team.TotalPoints += 8;
                    break;

                case 7:
                    team.Points += 6;
                    team.TotalPoints += 6;
                    break;

                case 8:
                    team.Points += 4;
                    team.TotalPoints += 4;
                    break;

                case 9:
                    team.Points += 2;
                    team.TotalPoints += 2;
                    break;

                case 10:
                    team.Points += 1;
                    team.TotalPoints += 1;
                    break;
            }

            if (team.BestResult > model.RacePosition)
            {
                team.BestResult = model.RacePosition;
                team.BestResultCount = 1;
            }
            else if (team.BestResult == model.RacePosition)
            {
                team.BestResultCount++;
            }

            await this.dbContext.SaveChangesAsync();
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

        public async Task<EditTeamViewModel> GetTeamForEditById(int id)
        {
            EditTeamViewModel team = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam && t.Id == id)
                .Select(t => new EditTeamViewModel
                {
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                }).FirstAsync();

            return team;
        }

        public async Task<bool> IsGridOfTeamsFull()
        {
            int teamsCount = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .CountAsync();

            return teamsCount == MaxTeams;
        }

        public async Task ResetAsync()
        {
            var activeTeams = await this.dbContext.Teams
                .Where(t => t.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.BestResult.HasValue)
                .ThenBy(t => t.BestResult)
                .ThenByDescending(t => t.BestResultCount.HasValue)
                .ThenBy(t => t.BestResultCount)
                .ToArrayAsync();

            var champion = activeTeams.First();

            champion.Championships++;

            int lastYearStanding = 1;

            foreach (var team in activeTeams)
            {
                team.Points = 0;
                team.BestResult = null;
                team.BestResultCount = null;
                team.LastYearStanding = lastYearStanding;
                lastYearStanding++;

                foreach (var draftUser in team.DraftUsers)
                {
                    draftUser.TeamId = null;
                }
            }

            await this.dbContext.SaveChangesAsync();
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

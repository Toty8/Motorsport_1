namespace Mototsport1.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Web.ViewModels.Driver;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.GeneralApplicationConstants;

    public class DriverService : IDriverService
    {
        private readonly Motorsport1DbContext dbContext;

        public DriverService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllDriverViewModel>> AllAsync()
        {
            ICollection<AllDriverViewModel> drivers = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderBy(d => d.Team!.LastYearStanding)
                .ThenBy(d => d.LastYearStanding == null)
                .Select(d => new AllDriverViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Number = d.Number,
                    TeamName = d.Team!.Name
                })
                .ToArrayAsync();

            return drivers;
        }

        public async Task DeleteAsync(int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where(d => d.Team != null)
                .FirstAsync(d => d.Id == id);

            driver.TeamId = null;
            driver.Team = null;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await this.dbContext.Drivers
                .Where(d => d.Team != null)
                .AnyAsync(d => d.Id == id);
        }

        public async Task<DriverDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Driver model =
                await this.dbContext.Drivers
                .Include(d => d.Team)
                .Where(d => d.Team != null)
                .FirstAsync(d => d.Id == id);

            return new DriverDetailsViewModel
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate,
                ImageUrl = model.ImageUrl,
                Number = model.Number,
                Championships = model.Championships,
                Wins = model.Wins,
                PolePositions = model.PolePositions,
                Podiums = model.Podiums,
                Points = model.Points,
                TotalPoints = model.TotalPoints,
                TeamName = model.Team!.Name
            };
        }

        public async Task<DriverPreDeleteViewModel> GetDriverForDeleteById(int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where (d => d.Team != null)
                .FirstAsync(d => d.Id == id);

            return new DriverPreDeleteViewModel
            {
                Name = driver.Name,
                ImageUrl = driver.ImageUrl,
            };
        }

        public async Task<bool> IsGridOfDriversFull()
        {
            int driversCount = await this.dbContext.Drivers
                .Where(d => d.Team != null)
                .CountAsync();

            return driversCount == MaxDrivers;
        }
    }
}

namespace Mototsport1.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Web.ViewModels.Driver;
    using Motorsport1.Web.ViewModels.Standing;
    using Mototsport1.Services.Data.Interfaces;
    using System.Globalization;
    using static Motorsport1.Common.GeneralApplicationConstants;

    public class DriverService : IDriverService
    {
        private readonly Motorsport1DbContext dbContext;

        public DriverService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewAsync(AddNewDriverViewModel model)
        {
            Driver driver = new Driver()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Number = model.Number,
                TeamId = model.TeamId,
                Price = model.Price,
                BirthDate = DateTime.ParseExact(model.BirthDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
            };

            await this.dbContext.Drivers.AddAsync(driver);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddOldAsync(AddOldDriverViewModel model)
        {
            Driver driver = await this.dbContext.Drivers
                .FirstAsync(d => d.Name == model.Name);

            driver.ImageUrl = model.ImageUrl;

            driver.TeamId = model.TeamId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllDriverViewModel>> AllAsync()
        {
            ICollection<AllDriverViewModel> drivers = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam)
                .OrderByDescending(d => d.Team!.LastYearStanding.HasValue)
                .ThenBy(d => d.Team!.LastYearStanding)
                .ThenByDescending(d => d.LastYearStanding.HasValue)
                .ThenBy(d => d.LastYearStanding)
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

        public async Task<IEnumerable<DriverDraftNamesViewModel>> AllNamesWithPricesAsync()
        {
            IEnumerable<DriverDraftNamesViewModel> driversNames = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam || d.BestResult != null)
                .OrderByDescending(d => d.Price)
                .Select(d => new DriverDraftNamesViewModel
                {
                    Id = d.Id,
                    Name = $"{d.Name} - {d.Price:f2}$",
                })
                .ToArrayAsync();

            return driversNames;
        }

        public async Task DeleteAsync(int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where(d => d.TeamId != null)
                .FirstAsync(d => d.Id == id);

            driver.TeamId = null;
            driver.Team = null;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EditDriverViewModel model, int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where (d => d.TeamId != null)
                .FirstAsync (d => d.Id == id);

            driver.Number = model.Number;
            driver.TeamId = model.TeamId;
            driver.ImageUrl = model.ImageUrl;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditDraftPriceAsync(decimal price, int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam || d.BestResult != null)
                .FirstAsync(d => d.Id == id);

            driver.Price = price;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditDriverStatisticsAsync(EditDriverStatisticsViewModel model, int id)
        {
            Driver driver = await this.dbContext.Drivers
                .Where(d => d.TeamId != null)
                .FirstAsync(d => d.Id == id);

            if (model.WasDriverOnPolePosition)
            {
                driver.PolePositions++;
            }

            if (model.DriverHaveFastestLap)
            {
                driver.Points++;
                driver.TotalPoints++;
            }

            switch (model.RacePosition)
            {
                case 1:
                    driver.Points+=25;
                    driver.TotalPoints+=25;
                    driver.Wins++;
                    driver.Podiums++;
                    break;
                    
                case 2:
                    driver.Points += 18;
                    driver.TotalPoints += 18;
                    driver.Podiums++;
                    break;

                case 3:
                    driver.Points += 15;
                    driver.TotalPoints += 15;
                    driver.Podiums++;
                    break;

                case 4:
                    driver.Points += 12;
                    driver.TotalPoints += 12;
                    break;

                case 5:
                    driver.Points += 10;
                    driver.TotalPoints += 10;
                    break;

                case 6:
                    driver.Points += 8;
                    driver.TotalPoints += 8;
                    break;

                case 7:
                    driver.Points += 6;
                    driver.TotalPoints += 6;
                    break;

                case 8:
                    driver.Points += 4;
                    driver.TotalPoints += 4;
                    break;

                case 9:
                    driver.Points += 2;
                    driver.TotalPoints += 2;
                    break;

                case 10:
                    driver.Points += 1;
                    driver.TotalPoints += 1;
                    break;
            }

            if (driver.BestResult > model.RacePosition)
            {
                driver.BestResult = model.RacePosition;
                driver.BestResultCount = 1;
            }
            else if (driver.BestResult == model.RacePosition)
            {
                driver.BestResultCount++;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await this.dbContext.Drivers
                .Where(d => d.TeamId != null)
                .AnyAsync(d => d.Id == id);
        }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await this.dbContext.Drivers
                .AnyAsync(d => d.Name == name);
        }

        public async Task<DriverDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Driver model =
                await this.dbContext.Drivers
                .Include(d => d.Team)
                .Where(d => d.TeamId != null)
                .FirstAsync(d => d.Id == id);

            return new DriverDetailsViewModel
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
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
                .Where(d => d.TeamId != null)
                .FirstAsync(d => d.Id == id);

            return new DriverPreDeleteViewModel
            {
                Name = driver.Name,
                ImageUrl = driver.ImageUrl,
            };
        }

        public async Task<EditDriverViewModel> GetDriverForEditById(int id, int teamId)
        {
            EditDriverViewModel model = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Id == id)
                .Select(d => new EditDriverViewModel
                {
                    Number = d.Number,
                    ImageUrl = d.ImageUrl,
                    TeamId = teamId
                }).FirstAsync();

            return model;
        }

        public async Task<int> GetNumberByIdAsync(int driverId)
        {
            return await this.dbContext.Drivers
                .Where(d => d.TeamId != null && driverId == d.Id)
                .Select(d => d.Number)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetTeamIdByDriverId(int id)
        {
            return await this.dbContext.Drivers
                .Where(d => d.Id == id)
                .Select(d => d.Team!.Id)
                .FirstAsync();
        }

        public async Task<bool> IsDriverCurrentChampion(int id)
        {
            bool isChamopion = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Id == id)
                .Select(d => d.IsCurrentChampion)
                .FirstOrDefaultAsync();

            return isChamopion;
        }

        public async Task<bool> IsThisNumberTaken(int number)
        {
            return await this.dbContext.Drivers
                .AnyAsync(d => d.Number == number);
        }

        public async Task ResetAsync()
        {
            var activeDrivers = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam || d.BestResult != null)
                .OrderByDescending(d => d.Points)
                .ThenByDescending(d => d.BestResult.HasValue)
                .ThenBy(d => d.BestResult)
                .ThenByDescending(d => d.BestResultCount.HasValue)
                .ThenBy(d => d.BestResultCount)
                .ToArrayAsync();

            var champion = activeDrivers.First();

            champion.IsCurrentChampion = true;
            champion.Championships++;

            int lastYearStanding = 1;

            foreach (var driver in activeDrivers) 
            {
                driver.Points = 0;
                driver.BestResult = null;
                driver.BestResultCount = null;
                driver.LastYearStanding = lastYearStanding;
                lastYearStanding++;

                foreach (var draftUser in driver.DraftUsers)
                {
                    draftUser.DriverId = null;
                }
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DriversStandingViewModel>> StandingAsync()
        {
            IEnumerable<DriversStandingViewModel> drivers = await this.dbContext.Drivers
                .Where(d => d.TeamId != null && d.Team!.Drivers.Count == MaxDriversPerTeam || d.BestResult != null)
                .OrderByDescending(d => d.Points)
                .ThenByDescending(d => d.BestResult.HasValue)
                .ThenBy(d => d.BestResult)
                .ThenByDescending(d => d.BestResultCount.HasValue)
                .ThenBy(d => d.BestResultCount)
                .Select(d => new DriversStandingViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Points = d.Points,
                    TeamName = d.Team!.Name
                }).ToArrayAsync();

            return drivers;
        }
    }
}

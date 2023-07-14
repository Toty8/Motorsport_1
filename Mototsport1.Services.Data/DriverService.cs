using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Web.ViewModels.Driver;
using Mototsport1.Services.Data.Interfaces;

namespace Mototsport1.Services.Data
{
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
                .Where(d => d.TeamId != null)
                .OrderBy(d => d.Team!.LastYearStanding)
                .ThenBy(d => d.LastYearStanding == null)
                .Select(d => new AllDriverViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Number = d.Number,
                    Team = d.Team!.Name
                })
                .ToArrayAsync();

            return drivers;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Web.ViewModels.Draft;
using Mototsport1.Services.Data.Interfaces;

namespace Mototsport1.Services.Data
{
    public class DraftService : IDraftService
    {

        private readonly Motorsport1DbContext dbContext;

        public DraftService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DraftAllViewModel>> StandingAsync()
        {
            IEnumerable<DraftAllViewModel> drafts = await this.dbContext.Users
                .Where(u => u.DriverId != null && u.TeamId != null)
                .Select(u => new DraftAllViewModel()
                {
                    Email = u.Email,
                    Points = u.Driver!.Points + u.Team!.Points + Decimal.ToDouble((100 - (u.Driver!.Price + u.Team!.Price)) * 5),
                    DriverName = u.Driver!.Name,
                    TeamName = u.Team!.Name,
                })
                .ToArrayAsync();

            return drafts;
        }
    }
}

namespace Motorsport1.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Draft;
    using Motorsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.GeneralApplicationConstants;

    public class DraftService : IDraftService
    {

        private readonly Motorsport1DbContext dbContext;

        public DraftService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> GetBudgetLeftAsync(string userId)
        {
            var user = await this.dbContext.Users
                .Include(u => u.Driver)
                .Where(u => u.DriverId != null)
                .FirstAsync(u => u.Id.ToString() == userId);

            decimal budget = DraftBudget;

            return budget -= user.Driver!.Price;
        }

        public async Task<bool> isThereSelectedDriverAsync(string userId)
        {
            return await this.dbContext.Users
                .Where(u => u.DriverId != null)
                .AnyAsync(u => u.Id.ToString() == userId);
        }

        public async Task<bool> IsUserDraftedAsync(string userId)
        {
            return await this.dbContext.Users
                .Where(u => u.TeamId != null)
                .AnyAsync(u => u.Id.ToString() == userId);
        }

        public async Task SelectDriverAsync(int driverId, string userId)
        {
            var user = await this.dbContext.Users
                .Where(u => u.TeamId == null)
                .FirstAsync(u => u.Id.ToString() == userId);

            user.DriverId = driverId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task SelectTeamAsync(int teamId, string userId)
        {
            var user = await this.dbContext.Users
                .Where(u => u.TeamId == null)
                .FirstAsync(u => u.Id.ToString() == userId);

            user.TeamId = teamId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DraftAllViewModel>> StandingAsync()
        {
            IEnumerable<DraftAllViewModel> drafts = await this.dbContext.Users
                .AsQueryable()
                .Where(u => u.DriverId != null && u.TeamId != null)
                .To<DraftAllViewModel>()
                .ToArrayAsync();

            drafts = drafts.OrderByDescending(u => u.Points);

            return drafts;
        }
    }
}

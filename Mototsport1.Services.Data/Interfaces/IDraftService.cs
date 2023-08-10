using Motorsport1.Web.ViewModels.Draft;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface IDraftService
    {
        public Task<IEnumerable<DraftAllViewModel>> StandingAsync();

        public Task<bool> IsUserDraftedAsync(string userId);

        public Task<bool> IsThereSelectedDriverAsync(string userId);

        public Task SelectDriverAsync(int driverId, string userId);

        public Task SelectTeamAsync(int teamId, string userId);

        public Task<decimal> GetBudgetLeftAsync(string userId);
    }
}

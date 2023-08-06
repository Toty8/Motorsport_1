using Motorsport1.Web.ViewModels.Driver;
using Motorsport1.Web.ViewModels.Standing;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface IDriverService
    {
        public Task<IEnumerable<AllDriverViewModel>> AllAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<DriverDetailsViewModel> GetDetailsByIdAsync(int id);

        public Task<DriverPreDeleteViewModel> GetDriverForDeleteByIdAsync(int id);

        public Task DeleteAsync(int id);

        public Task AddOldAsync(AddOldDriverViewModel model);

        public Task<bool> ExistByNameAsync(string name);

        public Task AddNewAsync(AddNewDriverViewModel model);

        public Task<bool> IsThisNumberTakenAsync(int number);

        public Task<EditDriverViewModel> GetDriverForEditByIdAsync(int id, int teamId);

        public Task<int> GetTeamIdByDriverIdAsync(int id);

        public Task EditAsync(EditDriverViewModel model, int id);

        public Task<int> GetNumberByIdAsync(int driverId);

        public Task<bool> IsDriverCurrentChampionAsync(int id);

        public Task<IEnumerable<DriversStandingViewModel>> StandingAsync();

        public Task ResetAsync();

        public Task EditDriverStatisticsAsync(EditDriverStatisticsViewModel model, int id);

        public Task<IEnumerable<DriverDraftNamesViewModel>> AllNamesWithPricesAsync();

        public Task EditDraftPriceAsync(decimal price, int id);

        public Task<bool> DoesTeamHaveFreeSeatAsync(int id);
    }
}

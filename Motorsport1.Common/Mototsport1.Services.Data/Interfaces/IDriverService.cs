using Motorsport1.Web.ViewModels.Driver;
using Motorsport1.Web.ViewModels.Standing;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IDriverService
    {
        public Task<IEnumerable<AllDriverViewModel>> AllAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<DriverDetailsViewModel> GetDetailsByIdAsync(int id);

        public Task<DriverPreDeleteViewModel> GetDriverForDeleteById(int id);

        public Task DeleteAsync(int id);

        public Task AddOldAsync(AddOldDriverViewModel model);

        public Task<bool> ExistByNameAsync(string name);

        public Task AddNewAsync(AddNewDriverViewModel model);

        public Task<bool> IsThisNumberTaken(int number);

        public Task<EditDriverViewModel> GetDriverForEditById(int id, int teamId);

        public Task<int> GetTeamIdByDriverId(int id);

        public Task EditAsync(EditDriverViewModel model, int id);

        public Task<int> GetNumberByIdAsync(int driverId);

        public Task<bool> IsDriverCurrentChampion(int id);

        public Task<IEnumerable<DriversStandingViewModel>> StandingAsync();
    }
}

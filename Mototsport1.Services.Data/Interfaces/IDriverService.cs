using Motorsport1.Web.ViewModels.Driver;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IDriverService
    {
        public Task<IEnumerable<AllDriverViewModel>> AllAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<DriverDetailsViewModel> GetDetailsByIdAsync(int id);

        public Task<bool> IsGridOfDriversFull();

        public Task<DriverPreDeleteViewModel> GetDriverForDeleteById(int id);

        public Task DeleteAsync(int id);
    }
}

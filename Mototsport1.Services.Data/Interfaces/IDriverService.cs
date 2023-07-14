using Motorsport1.Web.ViewModels.Driver;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IDriverService
    {
        public Task<IEnumerable<AllDriverViewModel>> AllAsync();
    }
}

using Motorsport1.Web.ViewModels.Draft;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IDraftService
    {
        public Task<IEnumerable<DraftAllViewModel>> StandingAsync();
    }
}

using Motorsport1.Web.ViewModels.Team;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface ITeamService
    {
        public Task<IEnumerable<TeamNamesViewModel>> AllTeamsAvailableAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<bool> DoesTeamHaveFreeSeat(int id);
    }
}
using Motorsport1.Web.ViewModels.Team;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface ITeamService
    {
        public Task<IEnumerable<TeamNamesViewModel>> AllTeamsAvailableAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<bool> DoesTeamHaveFreeSeat(int id);

        public Task<IEnumerable<TeamNamesViewModel>> AllTeamsAvailableAndDriversTeamAsync(int id);

        public Task<IEnumerable<AllTeamsViewModel>> AllAsync();

        public Task<TeamDetailsViewModel> GetDetailsByIdAsync(int id);

        public Task<TeamPreDeleteViewModel> GetForDeleteById(int id);

        public Task DeleteAsync(int id);

        public Task<bool> IsGridOfTeamsFull();

        public Task<bool> ExistByNameAsync(string name);

        public Task AddAsync(AddTeamViewModel model);
    }
}
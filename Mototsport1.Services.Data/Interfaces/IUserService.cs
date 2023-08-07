using Motorsport1.Data.Models;
using Motorsport1.Web.ViewModels.User;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetFullNameByEmailAsync(string email);

        public Task<string> GetFullNameByIdAsync(string userId);

        public Task<bool> ExistByEmailAsync(string email);

        public Task<string> GetPublisherRoleIdAsync();

        public Task<string> GetUserIdByEmailAsync(string email);

        public Task AddUserToRolePublisherAsync(string userId, string roleId);

        public Task<IEnumerable<UserViewModel>> AllAsync();

        public Task<bool> IsUserAdmin(string id);

        public Task<bool> IsUserPublisher(string id);
    }
}

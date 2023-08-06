using Motorsport1.Data.Models;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetFullNameByEmailAsync(string email);

        public Task<bool> ExistByEmailAsync(string email);

        public Task<string> GetPublisherRoleIdAsync();

        public Task<string> GetUserIdByEmailAsync(string email);

        public Task AddUserToRolePublisherAsync(string userId, string roleId);
    }
}

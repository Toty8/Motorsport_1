namespace Motorsport1.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Data.Interfaces;
    using static Common.GeneralApplicationConstants;

    public class UserService : IUserService
    {
        private readonly Motorsport1DbContext dbContext;

        public UserService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserToRolePublisherAsync(string userId, string roleId)
        {
            IdentityUserRole<Guid> userRole = new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse(roleId),
                UserId = Guid.Parse(userId),
            };

            var userRoles = await dbContext.UserRoles.AddAsync(userRole);

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByEmailAsync(string email)
        {
            return await this.dbContext.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return String.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetPublisherRoleIdAsync()
        {
            var user = await dbContext.Roles
                .FirstAsync(r => r.Name == PublisherRoleName);

            return user.Id.ToString();
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var user = await dbContext.Users
                .FirstAsync(u => u.Email == email);

            return user.Id.ToString();
        }
    }
}

namespace Motorsport1.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.User;
    using System.Collections.Generic;
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

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            ICollection<UserViewModel> allUsers = await this.dbContext.Users
                .To<UserViewModel>()
                .ToListAsync();

            return allUsers;
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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext.Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

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

        public async Task<bool> IsUserAdmin(string id)
        {
            var role = await this.dbContext.Roles
                .FirstAsync(r => r.Name == AdminRoleName);

            return await this.dbContext.UserRoles
                .AnyAsync(ur => ur.UserId == Guid.Parse(id) && ur.RoleId == role.Id);
        }

        public async Task<bool> IsUserPublisher(string id)
        {
            var role = await this.dbContext.Roles
                .FirstAsync(r => r.Name == PublisherRoleName);

            return await this.dbContext.UserRoles
                .AnyAsync(ur => ur.UserId == Guid.Parse(id) && ur.RoleId == role.Id);
        }
    }
}

namespace Mototsport1.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Mototsport1.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly Motorsport1DbContext dbContext;

        public UserService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}

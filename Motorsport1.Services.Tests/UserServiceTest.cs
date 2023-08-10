namespace Motorsport1.Services.Tests
{

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using static DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using Microsoft.AspNetCore.Identity;

    public class UserServiceTest
    {
        private static DbContextOptions<Motorsport1DbContext> dbOptions =
            new DbContextOptionsBuilder<Motorsport1DbContext>()
                .UseInMemoryDatabase(databaseName: "Motorsport1InMemory")
                .Options;

        private Motorsport1DbContext Context;

        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Context = new Motorsport1DbContext(dbOptions);

            Context.Database.EnsureCreated();

            SeedDatabase(this.Context);

            this.userService = new UserService(this.Context);
        }

        [OneTimeTearDown]
        public void ClearUp()
        {
            Context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddUserToRolePublisherAsyncShouldSucceed()
        {
            var roleId = this.Context.Roles
                .Where(r => r.Name == PublisherRoleName)
                .Select(r => r.Id)
                .First();

            await this.userService.AddUserToRolePublisherAsync(TestUser.Id.ToString(), roleId.ToString());

            var exist = this.Context.UserRoles
                .Any(ur => ur.UserId == TestUser.Id && ur.RoleId == roleId);

            Assert.True(exist);

            var userRole = this.Context.UserRoles
                .First(ur => ur.UserId == TestUser.Id && ur.RoleId == roleId);

            Context.UserRoles.Remove(userRole);

            Context.SaveChanges();
        }

        [Test]
        public async Task ExistByEmailAsyncShouldReturnTrue()
        {
            bool exist = await this.userService.ExistByEmailAsync(TestUser.Email);

            Assert.True(exist);
        }

        [Test]
        public async Task ExistByEmailAsyncShouldReturnFalse()
        {
            bool exist = await this.userService.ExistByEmailAsync("Super.Invalid@email.com");

            Assert.False(exist);
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldSucceed()
        {
            string fullName = await this.userService.GetFullNameByEmailAsync(TestUser.Email);

            Assert.That(fullName, Is.EqualTo("Unit Test"));
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldFailBecauseEmailIsInvalid()
        {
            string fullName = await this.userService.GetFullNameByEmailAsync("Super.Invalid@email.com");

            Assert.That(fullName, Is.EqualTo(String.Empty));
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldFailBecauseEmailIsNull()
        {
            string fullName = await this.userService.GetFullNameByEmailAsync(null);

            Assert.That(fullName, Is.EqualTo(String.Empty));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldSucceed()
        {
            string fullName = await this.userService.GetFullNameByIdAsync(TestUser.Id.ToString());

            Assert.That(fullName, Is.EqualTo("Unit Test"));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldFailBecauseEmailIsInvalid()
        {
            string fullName = await this.userService.GetFullNameByIdAsync("Super.Invalid@email.com");

            Assert.That(fullName, Is.EqualTo(String.Empty));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldFailBecauseEmailIsNull()
        {
            string fullName = await this.userService.GetFullNameByIdAsync(null);

            Assert.That(fullName, Is.EqualTo(String.Empty));
        }

        [Test]
        public async Task GetPublisherRoleIdAsyncShouldSucceed()
        {
            string publisherId = await this.userService.GetPublisherRoleIdAsync();

            Assert.That(publisherId, Is.EqualTo(TestPublisherRole.Id.ToString()));
        }

        [Test]
        public async Task GetUserIdByEmailAsyncShouldSucceed()
        {
            string userId = await this.userService.GetUserIdByEmailAsync(TestUser.Email);

            Assert.That(userId, Is.EqualTo(TestUser.Id.ToString()));
        }

        [Test]
        public async Task IsUserAdminShouldReturnTrue()
        {

            var roleUser = new IdentityUserRole<Guid>
            {
                RoleId = TestAdminRole.Id,
                UserId = TestUser.Id,
            };

            Context.UserRoles.Add(roleUser);

            Context.SaveChanges();

            bool isAdmin = await this.userService.IsUserAdmin(TestUser.Id.ToString());

            Assert.True(isAdmin);

            var userRole = this.Context.UserRoles
                .Where(ur => ur.RoleId == TestAdminRole.Id && ur.UserId == TestUser.Id)
                .First();

            Context.UserRoles.Remove(userRole);

            Context.SaveChanges();
        }

        [Test]
        public async Task IsUserAdminShouldReturnFalse()
        {
            bool isAdmin = await this.userService.IsUserAdmin(TestUser.Id.ToString());

            Assert.False(isAdmin);
        }

        [Test]
        public async Task IsUserPublisherShouldReturnTrue()
        {

            var roleUser = new IdentityUserRole<Guid>
            {
                RoleId = TestPublisherRole.Id,
                UserId = TestUser.Id,
            };

            Context.UserRoles.Add(roleUser);

            Context.SaveChanges();

            bool isPublisher = await this.userService.IsUserPublisher(TestUser.Id.ToString());

            Assert.True(isPublisher);

            var userRole = this.Context.UserRoles
                .Where(ur => ur.RoleId == TestPublisherRole.Id && ur.UserId == TestUser.Id)
                .First();

            Context.UserRoles.Remove(userRole);

            Context.SaveChanges();
        }

        [Test]
        public async Task IsUserPublisherShouldReturnFalse()
        {
            bool isPublisher = await this.userService.IsUserPublisher(TestUser.Id.ToString());

            Assert.False(isPublisher);
        }
    }
}

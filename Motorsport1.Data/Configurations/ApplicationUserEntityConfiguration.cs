namespace Motorsport1.Data.Configurations
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Motorsport1.Data.Models;
    using static Common.GeneralApplicationConstants;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne(u => u.Driver)
                .WithMany(d => d.DraftUsers)
                .HasForeignKey(u => u.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Team)
                .WithMany(t => t.DraftUsers)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Test");

            builder.HasData(this.GenerateUsers());
        }
        private ApplicationUser[] GenerateUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user;

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            user = new ApplicationUser()
            {
                Id = Guid.Parse("E15AEA71-C074-4164-BF8A-01B9F3DBB497"),
                Email = DevelopmentAdminEmail,
                NormalizedEmail = DevelopmentAdminEmail.ToUpper(),
                UserName = DevelopmentAdminEmail,
                NormalizedUserName = DevelopmentAdminEmail.ToUpper(),
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Admin",
                LastName = "Admin"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "123456");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("0DE4C685-3EA5-4F74-B54B-8464457A7E02"),
                Email = DevelopmentPublisherEmail,
                NormalizedEmail = DevelopmentPublisherEmail.ToUpper(),
                UserName = DevelopmentPublisherEmail,
                NormalizedUserName = DevelopmentPublisherEmail.ToUpper(),
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Publisher",
                LastName = "Publisher"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "123456");

            users.Add(user);

            return users.ToArray();
        }
    }
}

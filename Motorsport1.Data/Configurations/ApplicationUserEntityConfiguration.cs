namespace Motorsport1.Data.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Motorsport1.Data.Models;

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
        }
    }
}

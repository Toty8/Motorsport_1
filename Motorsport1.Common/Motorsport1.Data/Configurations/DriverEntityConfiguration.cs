using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class DriverEntityConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder
                .HasOne(d => d.Team)
                .WithMany(t => t.Drivers)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

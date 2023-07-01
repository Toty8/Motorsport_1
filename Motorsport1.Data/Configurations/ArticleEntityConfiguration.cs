using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Publisher)
                .WithMany(p => p.Articles)
                .HasForeignKey(a => a.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

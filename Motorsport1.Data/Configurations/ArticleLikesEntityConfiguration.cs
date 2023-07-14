using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class ArticleLikesEntityConfiguration : IEntityTypeConfiguration<LikedArticle>
    {
        public void Configure(EntityTypeBuilder<LikedArticle> builder)
        {
            builder.HasKey(l => new { l.UserId, l.ArticleId });
        }
    }
}

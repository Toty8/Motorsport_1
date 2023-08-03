using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.PublishedDateTime)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Publisher)
                .WithMany(p => p.Comments)
                .HasForeignKey(a => a.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateComments());
        }

        private Comment[] GenerateComments()
        {
            ICollection<Comment> comments = new HashSet<Comment>();

            Comment comment;

            comment = new Comment
            {
                Id = 1,
                Content = "Albon really deserve a better car!",
                ArticleId = 1,
                IsActive = true,
                PublisherId = Guid.Parse("E15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            comments.Add(comment);

            comment = new Comment
            {
                Id = 2,
                Content = "It was a great race!",
                ArticleId = 2,
                IsActive = true,
                PublisherId = Guid.Parse("E15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            comments.Add(comment);

            comment = new Comment
            {
                Id = 3,
                Content = "Ferrari is back in the game!",
                ArticleId = 2,
                IsActive = true,
                PublisherId = Guid.Parse("E15AEA71-C074-4164-BF8A-01B9F3DBB497"),
            };

            comments.Add(comment);

            return comments.ToArray();
        }
    }
}

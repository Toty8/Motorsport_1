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

            builder
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
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
            };

            comments.Add(comment);

            comment = new Comment
            {
                Id = 2,
                Content = "It was a great race!",
                ArticleId = 2,
            };

            comments.Add(comment);

            comment = new Comment
            {
                Id = 3,
                Content = "Ferrari is back in the game!",
                ArticleId = 2,
            };

            comments.Add(comment);

            return comments.ToArray();
        }  
    }
}

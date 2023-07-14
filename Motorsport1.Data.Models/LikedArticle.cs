namespace Motorsport1.Data.Models
{
    public class LikedArticle
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}

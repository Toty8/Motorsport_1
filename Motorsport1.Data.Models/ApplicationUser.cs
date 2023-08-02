namespace Motorsport1.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Articles = new HashSet<Article>();
            this.LikedArticles = new HashSet<LikedArticle>();
            this.Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public int? DriverId { get; set; }

        public virtual Driver? Driver { get; set; }

        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }

        public virtual ICollection<LikedArticle> LikedArticles { get; set; }
    }
}

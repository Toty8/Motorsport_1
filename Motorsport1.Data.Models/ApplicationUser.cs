namespace Motorsport1.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidationConstants.User;

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

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public int? DriverId { get; set; }

        public virtual Driver? Driver { get; set; }

        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }

        public virtual ICollection<LikedArticle> LikedArticles { get; set; }
    }
}

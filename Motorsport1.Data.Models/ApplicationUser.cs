namespace Motorsport1.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Articles = new HashSet<Article>();
        }

        public virtual ICollection<Article> Articles { get; set; }

        public int? DriverId { get; set; }

        public virtual Driver? Driver { get; set; }

        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}

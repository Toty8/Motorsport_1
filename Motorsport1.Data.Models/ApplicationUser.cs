﻿namespace Motorsport1.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Articles = new HashSet<Article>();
        }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
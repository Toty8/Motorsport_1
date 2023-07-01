﻿namespace Motorsport1.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data.Models;
    using System.Reflection;

    public class Motorsport1DbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public Motorsport1DbContext(DbContextOptions<Motorsport1DbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(Motorsport1DbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
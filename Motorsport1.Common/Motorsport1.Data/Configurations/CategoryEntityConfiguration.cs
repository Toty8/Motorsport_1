using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Very Important",
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "News",
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Race Report",
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Press Conference",
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}

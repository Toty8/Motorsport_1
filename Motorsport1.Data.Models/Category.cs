namespace Motorsport1.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Category;

    public class Category
    {

        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Article> Articles { get; set; }

    }
}
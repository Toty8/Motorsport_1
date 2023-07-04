namespace Motorsport1.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Article;

    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(InformationMaxLength)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [DefaultValue(LikesDefaulValue)]
        public int Likes { get; set; }

        [DefaultValue(ReadCountDefaulValue)]
        public int ReadCount { get; set; }

        [Required]
        public DateTime PublishedDateTime { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid PublisherId { get; set; }

        public virtual ApplicationUser Publisher { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

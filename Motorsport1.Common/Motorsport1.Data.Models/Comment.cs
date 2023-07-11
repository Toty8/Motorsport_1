namespace Motorsport1.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Comment;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime PublishedDateTime { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; } = null!;
    }
}

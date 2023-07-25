namespace Motorsport1.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Comment;

    public class AddAndEditCommentViewModel
    {
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}

namespace Motorsport1.Web.ViewModels.Comment
{
    using Motorsport1.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Comment;
    using Data.Models;

    public class AddEditAndDeleteCommentViewModel : IMapFrom<Comment>, IMapTo<Comment>
    {
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}

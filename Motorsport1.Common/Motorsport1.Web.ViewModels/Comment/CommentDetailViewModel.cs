using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Comment
{
    public class CommentDetailViewModel
    {
        public string Content { get; set; } = null!;

        public DateTime PublishedDateTime { get; set; }
    }
}

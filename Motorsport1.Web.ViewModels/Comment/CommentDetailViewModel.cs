using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Comment
{
    public class CommentDetailViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public string PublishedDateTime { get; set; } = null!;

        public string PublisherId { get; set; } = null!;
    }
}

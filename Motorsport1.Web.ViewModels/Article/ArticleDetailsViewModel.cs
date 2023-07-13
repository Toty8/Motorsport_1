using Motorsport1.Web.ViewModels.Comment;
using Motorsport1.Web.ViewModels.Publisher;

namespace Motorsport1.Web.ViewModels.Article
{
    public class ArticleDetailsViewModel : AllArticleViewModel
    {
        public ArticleDetailsViewModel()
        {
            this.Comments = new HashSet<CommentDetailViewModel>();
        }

        public string Information { get; set; } = null!;

        public DateTime PublishedDateTime { get; set; }

        public virtual PublisherDetailsViewModel Publisher { get; set; } = null!;

        public virtual ICollection<CommentDetailViewModel> Comments { get; set; }
    }
}

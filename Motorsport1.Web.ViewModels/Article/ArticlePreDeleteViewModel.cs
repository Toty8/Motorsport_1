using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Article
{
    public class ArticlePreDeleteViewModel
    {
        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

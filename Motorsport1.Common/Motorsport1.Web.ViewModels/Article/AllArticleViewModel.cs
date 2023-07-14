using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Article
{
    public class AllArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public int Likes { get; set; }

        [Display(Name = "Read")]
        public int ReadCount { get; set; }
    }
}

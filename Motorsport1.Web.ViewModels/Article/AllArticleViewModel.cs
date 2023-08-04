namespace Motorsport1.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using Services.Mapping;
    using Data.Models;

    public class AllArticleViewModel : IMapFrom<Article>
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

namespace Motorsport1.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Services.Mapping;
    using Data.Models;

    public class ArticlePreDeleteViewModel : IMapFrom<Article>
    {
        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

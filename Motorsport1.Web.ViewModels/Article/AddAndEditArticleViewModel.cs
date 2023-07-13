namespace Motorsport1.Web.ViewModels.Article
{
    using Motorsport1.Web.ViewModels.Category;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Article;

    public class AddAndEditArticleViewModel
    {

        public AddAndEditArticleViewModel()
        {
            this.Categories = new HashSet<ArticleCategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(InformationMaxLength, MinimumLength = InformationMinLength)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<ArticleCategoryViewModel> Categories { get; set; }
    }
}

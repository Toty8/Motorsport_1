namespace Motorsport1.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Category;

    using Motorsport1.Data.Models;
    using static Common.EntityValidationConstants.Article;
    using AutoMapper;

    public class AddAndEditArticleViewModel : IMapTo<Article>, IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AddAndEditArticleViewModel, Article>()
                .ForMember(a => a.PublisherId, opt => opt.Ignore());
        }
    }
}

namespace Motorsport1.Web.ViewModels.Article
{

    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Comment;
    using Motorsport1.Web.ViewModels.Publisher;
    using Data.Models;
    using AutoMapper;
    using System.Globalization;

    public class ArticleDetailsViewModel : AllArticleViewModel, IHaveCustomMappings
    {
        public ArticleDetailsViewModel()
        {
            this.Comments = new HashSet<CommentDetailViewModel>();
        }

        public string Information { get; set; } = null!;

        public string PublishedDateTime { get; set; } = null!;

        public virtual PublisherDetailsViewModel Publisher { get; set; } = null!;

        public virtual ICollection<CommentDetailViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, ArticleDetailsViewModel>()
                .ForMember(a => a.PublishedDateTime,
                    opt => opt.MapFrom(src => src.PublishedDateTime.ToString("HH:mm dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(a => a.Comments, opt => opt.Ignore())
                .ForMember(a => a.Publisher, opt => opt.Ignore());
        }
    }
}

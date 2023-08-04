namespace Motorsport1.Web.ViewModels.Publisher
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Article;
    using System.Globalization;
    using static Motorsport1.Common.EntityValidationConstants;

    public class PublisherDetailsViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, PublisherDetailsViewModel>()
            .ForMember(a => a.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}

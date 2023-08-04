namespace Motorsport1.Web.ViewModels.Draft
{

    using Motorsport1.Services.Mapping;
    using Data.Models;
    using AutoMapper;
    using Motorsport1.Web.ViewModels.Article;
    using System.Globalization;

    public class DraftAllViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Email { get; set; } = null!;

        public double Points { get; set; }

        public string DriverName { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, DraftAllViewModel>()
                            .ForMember(a => a.Points,
                                opt => opt.MapFrom(src => src.Driver!.Points + src.Team!.Points + Decimal.ToDouble((100 - (src.Driver!.Price + src.Team!.Price)) * 5)))
                            .ForMember(a => a.DriverName, 
                                opt => opt.MapFrom(src => src.Driver!.Name))
                            .ForMember(a => a.TeamName,
                                opt => opt.MapFrom(src => src.Team!.Name));
        }
    }
}

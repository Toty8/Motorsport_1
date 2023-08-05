namespace Motorsport1.Web.ViewModels.Team
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Driver;

    public class TeamDraftNamesViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, TeamDraftNamesViewModel>()
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(src => $"{src.Name} - {src.Price:f2}$"));
        }
    }
}

namespace Motorsport1.Web.ViewModels.Team
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;

    public class TeamDetailsViewModel : AllTeamsViewModel
    {

        public int Championships { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public int PolePositions { get; set; }

        public double TotalPoints { get; set; }

        public override void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember(t => t.Drivers,
                    opt => opt.MapFrom(src => src.Drivers.Select(d => d.Name).ToArray()));
        }
    }
}

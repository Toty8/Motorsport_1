namespace Motorsport1.Web.ViewModels.Standing
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Team;
    using System.ComponentModel.DataAnnotations;

    public class TeamStandingViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamDrivers { get; set; } = null!;

        public double Points { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, TeamStandingViewModel>()
            .ForMember(t => t.TeamDrivers,
                    opt => opt.MapFrom(src => String.Join(" and ", src.Drivers.Select(d => d.Name).ToArray())));

        }
    }
}

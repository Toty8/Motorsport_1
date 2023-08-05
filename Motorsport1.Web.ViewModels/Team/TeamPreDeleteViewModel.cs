namespace Motorsport1.Web.ViewModels.Team
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using static Motorsport1.Common.EntityValidationConstants.Team;

    public class TeamPreDeleteViewModel : IMapFrom<Team>, IHaveCustomMappings
    {

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string Drivers { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, TeamPreDeleteViewModel>()
            .ForMember(t => t.Drivers,
                    opt => opt.MapFrom(src => String.Join(" and ", src.Drivers.Select(d => d.Name).ToArray())));
        }
    }
}

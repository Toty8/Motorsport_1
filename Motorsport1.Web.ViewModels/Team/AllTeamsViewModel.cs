namespace Motorsport1.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    public class AllTeamsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public AllTeamsViewModel()
        {
            this.Drivers = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<string> Drivers { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Team, AllTeamsViewModel>()
                .ForMember(t => t.Drivers,
                    opt => opt.MapFrom(src => src.Drivers.Select(d => d.Name).ToArray()));
        }
    }
}

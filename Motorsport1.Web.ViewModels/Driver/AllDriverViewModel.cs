namespace Motorsport1.Web.ViewModels.Driver
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    public class AllDriverViewModel : IMapFrom<Driver>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public int Number { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, AllDriverViewModel>()
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(src => src.Team!.Name));
        }
    }
}

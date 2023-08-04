namespace Motorsport1.Web.ViewModels.Standing
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;

    public class DriversStandingViewModel : IMapFrom<Driver>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public double Points { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, DriversStandingViewModel>()
                .ForMember(d => d.TeamName, 
                    opt => opt.MapFrom(src => src.Team!.Name));
        }
    }
}

namespace Motorsport1.Web.ViewModels.Driver
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using System.Globalization;

    public class DriverDetailsViewModel : AllDriverViewModel
    {

        public string BirthDate { get; set; } = null!;

        public int Championships { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public int PolePositions { get; set; }

        public double TotalPoints { get; set; }

        public override void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, DriverDetailsViewModel>()
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(src => src.Team!.Name))
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}

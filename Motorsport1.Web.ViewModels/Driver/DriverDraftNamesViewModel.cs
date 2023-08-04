namespace Motorsport1.Web.ViewModels.Driver
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;

    public class DriverDraftNamesViewModel : IMapFrom<Driver>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, DriverDraftNamesViewModel>()
                .ForMember(d => d.Name,
                opt => opt.MapFrom(src => $"{src.Name} - {src.Price:f2}$"));
        }
    }
}

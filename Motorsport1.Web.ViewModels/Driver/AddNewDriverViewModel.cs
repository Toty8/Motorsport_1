namespace Motorsport1.Web.ViewModels.Driver
{
    using AutoMapper;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using static Common.EntityValidationConstants.Driver;
    public class AddNewDriverViewModel : AddOldDriverViewModel, IMapTo<Driver>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(int), NumberMinValue, NumberMaxValue)]
        public int Number { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, AddNewDriverViewModel>()
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}

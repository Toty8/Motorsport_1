namespace Motorsport1.Web.ViewModels.Driver
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;

    public class DriverPreDeleteViewModel : IMapFrom<Driver>
    {
        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

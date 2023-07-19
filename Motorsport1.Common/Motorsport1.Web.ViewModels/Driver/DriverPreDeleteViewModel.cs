using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Driver
{
    public class DriverPreDeleteViewModel
    {
        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

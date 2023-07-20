using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Motorsport1.Web.ViewModels.Standing
{
    public class DriversStandingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public double Points { get; set; }
    }
}

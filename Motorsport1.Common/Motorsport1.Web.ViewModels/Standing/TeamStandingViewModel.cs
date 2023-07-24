using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Standing
{
    public class TeamStandingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamDrivers { get; set; } = null!;

        public double Points { get; set; }
    }
}

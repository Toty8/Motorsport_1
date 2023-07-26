namespace Motorsport1.Web.ViewModels.Standing
{

    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Standing;

    public class EditDriverStatisticsViewModel
    {
        [Required]
        [Range(typeof(int), PositionMinValue, PositionMaxValue)]
        [Display(Name = "Race Position")]
        public int RacePosition { get; set; }

        [Required]
        [Display(Name = "Pole Position")]
        public bool WasDriverOnPolePosition { get; set; }

        [Required]
        [Display(Name = "Fastest Lap")]
        public bool DriverHaveFastestLap { get; set; }
    }
}

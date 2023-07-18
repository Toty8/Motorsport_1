namespace Motorsport1.Web.ViewModels.Driver
{
    using Motorsport1.Web.ViewModels.Team;

    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Driver;

    public class EditDriverViewModel
    {
        public EditDriverViewModel()
        {
            this.Teams = new HashSet<TeamNamesViewModel>();
        }

        [Required]
        [Range(typeof(int), NumberMinValue, NumberMaxValue)]
        public int Number { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamNamesViewModel> Teams { get; set; }
    }
}

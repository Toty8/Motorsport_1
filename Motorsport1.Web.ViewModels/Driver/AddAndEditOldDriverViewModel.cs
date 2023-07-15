namespace Motorsport1.Web.ViewModels.Driver
{
    using Motorsport1.Web.ViewModels.Team;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Driver;
    public class AddAndEditOldDriverViewModel
    {
        public AddAndEditOldDriverViewModel()
        {
            this.Teams = new HashSet<TeamNamesViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public int TeamId { get; set; }

        public IEnumerable<TeamNamesViewModel> Teams { get; set; } 
    }
}

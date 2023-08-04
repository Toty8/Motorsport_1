namespace Motorsport1.Web.ViewModels.Driver
{
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Team;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Driver;
    public class AddOldDriverViewModel : IMapTo<Driver>
    {
        public AddOldDriverViewModel()
        {
            this.Teams = new HashSet<TeamNamesViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamNamesViewModel> Teams { get; set; } 
    }
}

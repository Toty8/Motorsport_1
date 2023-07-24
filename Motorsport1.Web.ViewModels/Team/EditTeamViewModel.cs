namespace Motorsport1.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Team;

    public class EditTeamViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

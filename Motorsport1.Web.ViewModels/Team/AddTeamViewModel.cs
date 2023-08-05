namespace Motorsport1.Web.ViewModels.Team
{
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Team;

    public class AddTeamViewModel : IMapTo<Team>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}

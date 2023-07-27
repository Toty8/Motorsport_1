namespace Motorsport1.Web.ViewModels.Draft
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Web.ViewModels.Team;
    using static Common.EntityValidationConstants.Team;

    public class DraftEditTeamViewModel
    {
        public DraftEditTeamViewModel()
        {
            this.NamesAndPrices = new HashSet<TeamDraftNamesViewModel>();
        }

        [Display(Name = "Team")]
        public int Id { get; set; }

        public IEnumerable<TeamDraftNamesViewModel> NamesAndPrices { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}

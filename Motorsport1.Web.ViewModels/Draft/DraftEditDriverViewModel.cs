namespace Motorsport1.Web.ViewModels.Draft
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Web.ViewModels.Driver;
    using static Common.EntityValidationConstants.Driver;

    public class DraftEditDriverViewModel
    {

        public DraftEditDriverViewModel()
        {
            this.NamesAndPrices = new HashSet<DriverDraftNamesViewModel>();
        }

        [Display(Name = "Driver")]
        public int Id { get; set; }

        public IEnumerable<DriverDraftNamesViewModel> NamesAndPrices { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}

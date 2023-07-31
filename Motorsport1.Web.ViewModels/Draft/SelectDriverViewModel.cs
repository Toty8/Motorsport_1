namespace Motorsport1.Web.ViewModels.Draft
{
    using System.ComponentModel.DataAnnotations;

    using Motorsport1.Web.ViewModels.Driver;

    public class SelectDriverViewModel
    {
        public SelectDriverViewModel()
        {
            this.NamesAndPrices = new HashSet<DriverDraftNamesViewModel>();
        }

        [Display(Name = "Driver")]
        public int Id { get; set; }

        public IEnumerable<DriverDraftNamesViewModel> NamesAndPrices { get; set; }
    }
}

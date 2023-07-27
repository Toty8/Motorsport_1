using Motorsport1.Web.ViewModels.Driver;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Motorsport1.Web.ViewModels.Draft
{
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

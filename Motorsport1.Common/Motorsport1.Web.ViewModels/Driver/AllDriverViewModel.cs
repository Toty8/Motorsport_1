using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Motorsport1.Web.ViewModels.Driver
{
    public class AllDriverViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public int Number { get; set; }
    }
}

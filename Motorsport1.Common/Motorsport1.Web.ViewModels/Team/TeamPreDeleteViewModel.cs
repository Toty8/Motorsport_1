using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Motorsport1.Web.ViewModels.Team
{
    public class TeamPreDeleteViewModel
    {

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string Drivers { get; set; }
    }
}

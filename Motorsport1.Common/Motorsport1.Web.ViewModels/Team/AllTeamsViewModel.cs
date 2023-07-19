using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Motorsport1.Web.ViewModels.Team
{
    public class AllTeamsViewModel
    {
        public AllTeamsViewModel()
        {
            this.Drivers = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<string> Drivers { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Draft
{
    public class DraftAllViewModel
    {
        public string Email { get; set; } = null!;

        public double Points { get; set; }

        public string DriverName { get; set; } = null!;

        public string TeamName { get; set; } = null!;
    }
}

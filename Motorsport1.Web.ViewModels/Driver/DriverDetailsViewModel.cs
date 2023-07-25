using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Driver
{
    public class DriverDetailsViewModel : AllDriverViewModel
    {

        public string BirthDate { get; set; } = null!;

        public int Championships { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public int PolePositions { get; set; }

        public double TotalPoints { get; set; }
    }
}

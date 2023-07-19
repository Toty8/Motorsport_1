namespace Motorsport1.Web.ViewModels.Team
{
    public class TeamDetailsViewModel : AllTeamsViewModel
    {

        public int Championships { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public int PolePositions { get; set; }

        public double TotalPoints { get; set; }
    }
}

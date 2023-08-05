namespace Motorsport1.Web.ViewModels.Team
{
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Mapping;

    public class TeamNamesViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

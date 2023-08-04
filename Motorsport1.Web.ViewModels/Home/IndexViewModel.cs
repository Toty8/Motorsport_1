namespace Motorsport1.Web.ViewModels.Home
{

    using Services.Mapping;

    using Data.Models;

    public class IndexViewModel : IMapFrom<Article>
    {

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}

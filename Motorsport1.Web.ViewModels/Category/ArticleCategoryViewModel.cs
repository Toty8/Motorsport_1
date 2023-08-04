namespace Motorsport1.Web.ViewModels.Category
{

    using Motorsport1.Services.Mapping;
    using Data.Models;

    public class ArticleCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

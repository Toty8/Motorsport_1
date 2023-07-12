using System.ComponentModel.DataAnnotations;

namespace Motorsport1.Web.ViewModels.Category
{
    public class ArticleCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

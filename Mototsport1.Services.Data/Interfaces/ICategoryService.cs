using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Category;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<ArticleCategoryViewModel>> AllCategoriesAsync();

        public Task<bool> ExistByIdAsync(int id);

        public Task<IEnumerable<string>> AllNamesAsync();
    }
}

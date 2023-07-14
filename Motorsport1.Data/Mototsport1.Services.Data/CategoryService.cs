using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Web.ViewModels.Category;
using Mototsport1.Services.Data.Interfaces;

namespace Mototsport1.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly Motorsport1DbContext dbContext;

        public CategoryService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleCategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<ArticleCategoryViewModel> categories =
                await dbContext.Categories
                .AsNoTracking()
                .Select(c => new ArticleCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToArrayAsync();

            return categories;
        }

        public async Task<IEnumerable<string>> AllNamesAsync()
        {
            IEnumerable<string> names = await dbContext.Categories
                .AsNoTracking()
                .Select(a => a.Name)
                .ToArrayAsync();

            return names;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await dbContext.Categories.AnyAsync(c => c.Id == id);

            return result;
        }
    }
}

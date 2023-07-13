using Motorsport1.Services.Data.Models.Article;
using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Home;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IArticleService
    {
        public Task<IEnumerable<IndexViewModel>> GetLastFiveArticlesAsync();

        public Task AddArticleAsync(AddAndEditArticleViewModel model, string publisherId);

        public Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel);

        public Task<IEnumerable<AllArticleViewModel>> MineAsync(string publisherId);

        public Task<ArticleDetailsViewModel> GetDetailsByIdAsync(int articleId);

        public Task<bool> ExistByIdAsync(int id);

        public Task EditAsync(AddAndEditArticleViewModel article, int articleId);

        public Task<AddAndEditArticleViewModel> GetArticleToEditAsync(int id);
    }
}

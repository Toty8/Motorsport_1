using Motorsport1.Services.Data.Models.Article;
using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Home;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface IArticleService
    {
        public Task<IEnumerable<IndexViewModel>> GetLastFiveArticlesAsync();

        public Task<int> AddArticleAsync(AddAndEditArticleViewModel model, string publisherId);

        public Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel);

        public Task<IEnumerable<AllArticleViewModel>> MineAsync(string publisherId);

        public Task<ArticleDetailsViewModel> GetDetailsByIdAsync(int articleId);

        public Task<bool> ExistByIdAsync(int id);

        public Task EditAsync(AddAndEditArticleViewModel article, int articleId);

        public Task<AddAndEditArticleViewModel> GetArticleToEditAsync(int id);

        public Task<ArticlePreDeleteViewModel> GetArticleForDeleteByIdAsync(int id);

        public Task DeleteAsync(int id);

        public Task<bool> IsArticleLikedAsync(int id, string userId);

        public Task LikeArticleAsync(int articleId, string userId);

        public Task<bool> IsUserOwnerOfArticleAsync(int articleId, string userId);
    }
}

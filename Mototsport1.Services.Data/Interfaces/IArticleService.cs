using Motorsport1.Services.Data.Models.Article;
using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Home;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IArticleService
    {
        public Task<IEnumerable<IndexViewModel>> GetLastFiveArticles();

        public Task AddArticleAsync(AddArticleViewModel model, string publisherId);

        public Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel);
    }
}

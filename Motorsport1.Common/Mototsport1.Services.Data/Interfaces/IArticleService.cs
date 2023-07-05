using Motorsport1.Web.ViewModels.Home;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface IArticleService
    {
        public Task<IEnumerable<IndexViewModel>> GetLastFiveArticles();
    }
}

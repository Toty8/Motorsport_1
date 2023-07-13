using Motorsport1.Web.ViewModels.Article;

namespace Motorsport1.Services.Data.Models.Article
{
    public class AllArticlesFilteredAndPagedServiceModel
    {
        public AllArticlesFilteredAndPagedServiceModel()
        {
            this.Articles = new HashSet<AllArticleViewModel>();
        }

        public int TotalArticlesCount { get; set; }

        public ICollection<AllArticleViewModel> Articles { get; set; }
    }
}

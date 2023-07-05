using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Web.ViewModels.Home;
using Mototsport1.Services.Data.Interfaces;

namespace Mototsport1.Services.Data
{
    public class ArticleService : IArticleService
    {
        private readonly Motorsport1DbContext dbContext;

        public ArticleService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> GetLastFiveArticles()
        {
            var articles = await dbContext.Articles
                .OrderByDescending(a => a.PublishedDateTime)
                .Take(5)
                .Select(a => new IndexViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl
                })
                .ToArrayAsync();

            return articles;
        }
    }
}

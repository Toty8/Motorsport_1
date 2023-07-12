using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Data.Models;
using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Home;
using Mototsport1.Services.Data.Interfaces;
using System.ComponentModel;

namespace Mototsport1.Services.Data
{
    public class ArticleService : IArticleService
    {
        private readonly Motorsport1DbContext dbContext;

        public ArticleService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddArticleAsync(AddArticleViewModel model, string publisherId)
        {
            Article article = new Article()
            {
                Title = model.Title,
                Information = model.Information,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                PublisherId = Guid.Parse(publisherId)
            };

            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexViewModel>> GetLastFiveArticles()
        {
            var articles = await dbContext.Articles
                .Where(a => a.IsActive == true)
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

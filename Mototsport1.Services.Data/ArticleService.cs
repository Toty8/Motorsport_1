using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Data.Models;
using Motorsport1.Services.Data.Models.Article;
using Motorsport1.Web.ViewModels.Article;
using Motorsport1.Web.ViewModels.Publisher;
using Motorsport1.Web.ViewModels.Home;
using Mototsport1.Services.Data.Interfaces;
using System.ComponentModel;
using Motorsport1.Web.ViewModels.Comment;

namespace Mototsport1.Services.Data
{
    public class ArticleService : IArticleService
    {
        private readonly Motorsport1DbContext dbContext;

        public ArticleService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddArticleAsync(AddAndEditArticleViewModel model, string publisherId)
        {
            Article article = new Article()
            {
                Title = model.Title,
                Information = model.Information,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                PublisherId = Guid.Parse(publisherId)
            };

            await this.dbContext.Articles.AddAsync(article);
            await this.dbContext.SaveChangesAsync();

            return article.Id;
        }

        public async Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel)
        {
            IQueryable<Article> articleQuery = this.dbContext
                .Articles
                .Where(a => a.IsActive == true)
                .OrderByDescending(x => x.PublishedDateTime)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                articleQuery = articleQuery
                    .Where(a => a.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildcard = $"%{queryModel.SearchString.ToLower()}%";
                articleQuery = articleQuery
                    .Where(a => EF.Functions.Like(a.Title, wildcard) ||
                                EF.Functions.Like(a.Information, wildcard));
            }

            ICollection<AllArticleViewModel> allArticles = await articleQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ArticlesPerPage)
                .Take(queryModel.ArticlesPerPage)
                .Select(a => new AllArticleViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl,
                    Likes = a.Likes,
                    ReadCount = a.ReadCount,
                })
                .ToArrayAsync();

            int totalArticles = articleQuery.Count();

            return new AllArticlesFilteredAndPagedServiceModel()
            {
                TotalArticlesCount = totalArticles,
                Articles = allArticles
            };
        }

        public async Task DeleteAsync(int id)
        {
            Article article = await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .FirstAsync(a => a.Id == id);

            article.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(AddAndEditArticleViewModel article, int articleId)
        {
            Article currArticle = await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .FirstAsync(a => a.Id == articleId);

            currArticle.Title = article.Title;
            currArticle.Information = article.Information;
            currArticle.CategoryId = article.CategoryId;
            currArticle.ImageUrl = article.ImageUrl;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .AnyAsync(a => a.Id == id);
        }

        public async Task<ArticlePreDeleteViewModel> GetArticleForDeleteByIdAsync(int id)
        {
            Article article = await this.dbContext.Articles
                .Where (a => a.IsActive == true)
                .FirstAsync (a => a.Id == id);

            return new ArticlePreDeleteViewModel
            {
                Title = article.Title,
                ImageUrl = article.ImageUrl,
            };
        }

        public async Task<AddAndEditArticleViewModel> GetArticleToEditAsync(int id)
        {
            var article = await this.dbContext.Articles
                .Where(a => a.IsActive == true && a.Id == id)
                .Select(a => new AddAndEditArticleViewModel
                {
                    Title = a.Title,
                    Information = a.Information,
                    ImageUrl = a.ImageUrl,
                    CategoryId = a.CategoryId
                }).FirstAsync();

            return article;
        }

        public async Task<ArticleDetailsViewModel> GetDetailsByIdAsync(int articleId)
        {
            Article article = await this.dbContext.Articles
                .Include(a => a.Comments)
                .Include(a => a.Publisher)
                .Where(a => a.IsActive == true)
                .FirstAsync(a => a.Id == articleId);

            article.ReadCount++;

            await this.dbContext.SaveChangesAsync();

            ICollection<CommentDetailViewModel> comments = new HashSet<CommentDetailViewModel>();

            CommentDetailViewModel currentComment;

            foreach (Comment comment in article.Comments)
            {
                currentComment = new CommentDetailViewModel
                {
                    Content = comment.Content,
                    PublishedDateTime = comment.PublishedDateTime,
                };

                comments.Add(currentComment);
            }

            return new ArticleDetailsViewModel
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Likes = article.Likes,
                ReadCount = article.ReadCount,
                Information = article.Information,
                PublishedDateTime = article.PublishedDateTime,
                Publisher = new PublisherDetailsViewModel
                {
                    Email = article.Publisher.Email,
                },
                Comments = comments
                
            };
        }

        public async Task<IEnumerable<IndexViewModel>> GetLastFiveArticlesAsync()
        {
            var articles = await this.dbContext.Articles
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

        public async Task<IEnumerable<AllArticleViewModel>> MineAsync(string publisherId)
        {
            IEnumerable<AllArticleViewModel> articles = await this.dbContext.Articles
                .Where(a => a.IsActive == true && a.PublisherId.ToString() == publisherId)
                .Select(a => new AllArticleViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl,
                    Likes = a.Likes,
                    ReadCount = a.ReadCount,
                })
                .ToArrayAsync();

            return articles;
        }
    }
}

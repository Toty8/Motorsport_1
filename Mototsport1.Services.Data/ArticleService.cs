namespace Mototsport1.Services.Data
{
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;

    using Motorsport1.Data;
    using Motorsport1.Data.Models;
    using Motorsport1.Services.Data.Models.Article;
    using Motorsport1.Web.ViewModels.Article;
    using Motorsport1.Web.ViewModels.Publisher;
    using Motorsport1.Web.ViewModels.Home;
    using Mototsport1.Services.Data.Interfaces;
    using Motorsport1.Web.ViewModels.Comment;
    using Motorsport1.Services.Mapping;
    using AutoMapper;

    public class ArticleService : IArticleService
    {
        private readonly Motorsport1DbContext dbContext;

        public ArticleService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddArticleAsync(AddAndEditArticleViewModel model, string publisherId)
        {
            Article article = AutoMapperConfig.MapperInstance.Map<Article>(model);
            article.PublisherId = Guid.Parse(publisherId);

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
                .To<AllArticleViewModel>()
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

        public async Task EditAsync(AddAndEditArticleViewModel model, int articleId)
        {
            Article article = await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .FirstAsync(a => a.Id == articleId);

            AutoMapperConfig.MapperInstance.Map(model, article);

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
                .Where(a => a.IsActive == true)
                .FirstAsync(a => a.Id == id);

            ArticlePreDeleteViewModel preDeleteArticle = AutoMapperConfig.MapperInstance.Map<ArticlePreDeleteViewModel>(article);

            return preDeleteArticle;
        }

        public async Task<AddAndEditArticleViewModel> GetArticleToEditAsync(int id)
        {
            var article = await this.dbContext.Articles
                .Where(a => a.IsActive == true && a.Id == id)
                .To<AddAndEditArticleViewModel>()
                .FirstAsync();

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

            foreach (Comment comment in article.Comments.Where(c => c.IsActive == true))
            {
                currentComment = AutoMapperConfig.MapperInstance.Map<CommentDetailViewModel>(comment);

                comments.Add(currentComment);
            }

            ArticleDetailsViewModel articleDetails = AutoMapperConfig.MapperInstance.Map<ArticleDetailsViewModel>(article);

            articleDetails.Publisher = AutoMapperConfig.MapperInstance.Map<PublisherDetailsViewModel>(article.Publisher);
            articleDetails.Comments = comments.OrderBy(c => c.PublishedDateTime).ToArray();

            return articleDetails;
        }

        public async Task<IEnumerable<IndexViewModel>> GetLastFiveArticlesAsync()
        {
            var articles = await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .OrderByDescending(a => a.PublishedDateTime)
                .Take(5)
                .To<IndexViewModel>()
                .ToArrayAsync();

            return articles;
        }

        public async Task<bool> IsArticleLikedAsync(int id, string userId)
        {
            return await this.dbContext.LikedArticles
                .AnyAsync(la => la.UserId.ToString() == userId && la.ArticleId == id);
        }

        public async Task<bool> IsUserOwnerOfArticleAsync(int articleId, string userId)
        {
            return await this.dbContext.Articles
                .Where(a => a.IsActive == true)
                .AnyAsync(a => a.Id == articleId && a.PublisherId.ToString() == userId);
        }

        public async Task LikeArticleAsync(int articleId, string userId)
        {
            LikedArticle likedArticle = new LikedArticle
            {
                ArticleId = articleId,
                UserId = Guid.Parse(userId)
            };

            Article article = await this.dbContext.Articles
                .FirstAsync(a => a.Id == articleId);

            await this.dbContext.LikedArticles.AddAsync(likedArticle);

            article.Likes++;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllArticleViewModel>> MineAsync(string publisherId)
        {
            IEnumerable<AllArticleViewModel> articles = await this.dbContext.Articles
                .Where(a => a.IsActive == true && a.PublisherId.ToString() == publisherId)
                .To<AllArticleViewModel>()
                .ToArrayAsync();

            return articles;
        }
    }
}

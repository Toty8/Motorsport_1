﻿using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Data.Models;
using Motorsport1.Services.Data.Models.Article;
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

        public async Task<IEnumerable<AllArticleViewModel>> MineAsync(string publisherId)
        {
            IEnumerable<AllArticleViewModel> articles = await dbContext.Articles
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

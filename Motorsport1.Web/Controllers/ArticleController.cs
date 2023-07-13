﻿namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Motorsport1.Services.Data.Models.Article;
    using Motorsport1.Web.ViewModels.Article;
    using Mototsport1.Services.Data.Interfaces;
    using static Common.UIMessages;
    using static Common.NotificationMessageConstants;

    public class ArticleController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IArticleService articleService;

        public ArticleController(ICategoryService categoryService, IArticleService articleService)
        {
            this.categoryService = categoryService;
            this.articleService = articleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllArticlesQueryModel queryModel)
        {
            AllArticlesFilteredAndPagedServiceModel serviceModel = 
                await this.articleService.AllAsync(queryModel);
            
            queryModel.Articles = serviceModel.Articles;
            queryModel.TotalArticles = serviceModel.TotalArticlesCount;
            queryModel.Categories = await this.categoryService.AllNamesAsync();

            return this.View(queryModel);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddArticleViewModel model = new AddArticleViewModel();

            model.Categories = await this.categoryService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddArticleViewModel model)
        {
            bool exists = await categoryService.ExistByIdAsync(model.CategoryId);

            if (!exists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessages.InvalidCategory);
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                this.ModelState.AddModelError(string.Empty, ErrorMessages.InvalidModelState);

                return this.View(model);
            }

            try
            {
                await articleService.AddArticleAsync(model, GetUserId());
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedArticle;

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<AllArticleViewModel> model = await this.articleService.MineAsync(GetUserId());

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            ArticleDetailsViewModel? viewmodel = await this.articleService.GetDetailsByIdAsync(id);

            if (viewmodel == null)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction(nameof(All));
            }

            return View(viewmodel);
        }
    }
}

﻿namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Motorsport1.Services.Data.Models.Article;
    using Motorsport1.Web.ViewModels.Article;
    using Motorsport1.Services.Data.Interfaces;
    using static Common.UIMessages;
    using static Common.NotificationMessageConstants;
    using Motorsport1.Web.Infrastructure.Extensions;

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
        public async Task<IActionResult> All([FromQuery] AllArticlesQueryModel queryModel)
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
            if (!this.User.IsPublisher())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                AddAndEditArticleViewModel model = new AddAndEditArticleViewModel();

                model.Categories = await this.categoryService.AllCategoriesAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAndEditArticleViewModel model)
        {
            bool exists = await categoryService.ExistByIdAsync(model.CategoryId);

            if (!exists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessages.InvalidCategory);
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                int articleId = await articleService.AddArticleAsync(model, GetUserId());

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedArticle;

                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        public async Task<IActionResult> Mine()
        {
            if (!this.User.IsPublisher())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            IEnumerable<AllArticleViewModel> model = await this.articleService.MineAsync(GetUserId());

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                ArticleDetailsViewModel viewmodel = await this.articleService.GetDetailsByIdAsync(id);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError("All");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (!exist)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction(nameof(All));
            }

            bool isUserOwner = await this.articleService.IsUserOwnerOfArticleAsync(id, GetUserId());

            if (!this.User.IsAdmin() && !isUserOwner)
            {
                this.TempData[ErrorMessage] = ErrorMessages.NotYourArticle;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                var article = await this.articleService.GetArticleToEditAsync(id);

                article.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(article);
            }
            catch (Exception)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditArticleViewModel model, int id)
        {

            bool exists = await categoryService.ExistByIdAsync(model.CategoryId);

            if (!exists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessages.InvalidCategory);
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.articleService.EditAsync(model, id);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }

            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedArticle;

            return RedirectToAction(nameof(Details), new {id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction(nameof(All));
            }

            bool isUserOwner = await this.articleService.IsUserOwnerOfArticleAsync(id, GetUserId());

            if (!this.User.IsAdmin() && !isUserOwner)
            {
                this.TempData[ErrorMessage] = ErrorMessages.NotYourArticle;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                var article = await this.articleService.GetArticleForDeleteByIdAsync(id);

                return this.View(article);
            }
            catch (Exception)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ArticlePreDeleteViewModel model, int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction(nameof(All));
            }
            try
            {
                await this.articleService.DeleteAsync(id);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }

            this.TempData[InformationMessage] = InformationMessages.InformationDeletedArticle;

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            bool isArticleLiked = await this.articleService.IsArticleLikedAsync(id, GetUserId());

            if (isArticleLiked)
            {
                this.TempData[ErrorMessage] = ErrorMessages.AlreadyLikedArticle;

                return this.RedirectToAction(nameof(Details), new {id});
            }

            try
            {
                await this.articleService.LikeArticleAsync(id, GetUserId());
            }
            catch (Exception)
            {
                return this.GeneralError("All");
            }
            return this.RedirectToAction(nameof(Details), new { id });
        }
    }
}

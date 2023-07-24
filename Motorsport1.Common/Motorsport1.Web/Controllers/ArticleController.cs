namespace Motorsport1.Web.Controllers
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
            try
            {
                AddAndEditArticleViewModel model = new AddAndEditArticleViewModel();

                model.Categories = await this.categoryService.AllCategoriesAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
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

                return RedirectToAction(nameof(Details), new { articleId });
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
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
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

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
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditArticleViewModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            bool exists = await categoryService.ExistByIdAsync(model.CategoryId);

            if (!exists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessages.InvalidCategory);
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

            try
            {
                var article = await this.articleService.GetArticleForDeleteByIdAsync(id);

                return this.View(article);
            }
            catch (Exception)
            {
                return this.GeneralError();
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

            this.TempData[WarningMessage] = InformationMessages.InformationDeletedArticle;

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            bool isArticleLiked = await this.articleService.IsArticleLikedAsync(id, GetUserId());

            if (isArticleLiked)
            {
                this.TempData[ErrorMessage] = ErrorMessages.AllreadyLikedArticle;

                return this.RedirectToAction(nameof(Details), new {id});
            }

            try
            {
                await this.articleService.LikeArticleAsync(id, GetUserId());
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            return this.RedirectToAction(nameof(Details), new { id });
        }
        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(All));
        }
    }
}

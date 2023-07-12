namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Article;
    using Mototsport1.Services.Data.Interfaces;
    using static Common.ModelStateMessages;

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
        public async Task<IActionResult> All()
        {
            return View();
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
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessage.InvalidCategory);
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                this.ModelState.AddModelError(string.Empty, ErrorMessage.InvalidModelState);

                return this.View(model);
            }

            try
            {
                await articleService.AddArticleAsync(model, GetUserId());
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessage.UnexpectedError);
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }
            return RedirectToAction(nameof(All));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Article;
using Mototsport1.Services.Data.Interfaces;

namespace Motorsport1.Web.Controllers
{
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
    }
}

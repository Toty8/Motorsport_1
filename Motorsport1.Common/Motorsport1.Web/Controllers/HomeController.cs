namespace Motorsport1.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Mototsport1.Services.Data.Interfaces;
    using ViewModels.Home;


    public class HomeController : BaseController
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await articleService.GetLastFiveArticles();
             
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
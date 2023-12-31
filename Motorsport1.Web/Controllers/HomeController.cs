﻿namespace Motorsport1.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Web.Infrastructure.Extensions;
    using ViewModels.Home;
    using static Common.GeneralApplicationConstants;

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

            if (this.User.IsAdmin())
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName});
            }

            IEnumerable<IndexViewModel> viewModel = await articleService.GetLastFiveArticlesAsync();
             
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            if (statusCode == 401)
            {
                return this.View("Error401");
            }
            return this.View();
        }
    }
}
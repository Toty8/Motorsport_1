﻿namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Griesoft.AspNetCore.ReCaptcha;
    using Microsoft.Extensions.Caching.Memory;

    using Data.Models;
    using ViewModels.User;
    using static Common.NotificationMessageConstants;
    using static Common.GeneralApplicationConstants;
    using static Common.UIMessages;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMemoryCache memoryCache;

        public UserController(SignInManager<ApplicationUser> signInManager, 
                              UserManager<ApplicationUser> userManager,
                              IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action = "submit",
            ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await this.userManager.SetUserNameAsync(user, model.Email);
            await this.userManager.SetEmailAsync(user, model.Email);

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await this.signInManager.SignInAsync(user, false);
            this.memoryCache.Remove(UsersCacheKey);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl,
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateRecaptcha(Action = "submit",
            ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        
            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexpectedError;

                return this.View(model);
            }

            this.memoryCache.Remove(UsersCacheKey);

            return this.RedirectToAction(model.ReturnUrl ?? "Index", "Home");
        }
    }
}

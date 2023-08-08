using Motorsport1.Web.Controllers;

namespace Motorsport1.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.Infrastructure.Extensions;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using Motorsport1.Web.ViewModels.Admin;
    using Motorsport1.Services.Data.Interfaces;
    using static Motorsport1.Web.Infrastructure.Extensions.WebApplicationBuilderExtensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class HomeController : BaseAdminController
    {

        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [Route("AddPublisher")]
        public IActionResult AddPublisher()
        {
            try
            {
                AddPublisherViewModel model = new AddPublisherViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return GeneralError(null);
            }
        }

        [HttpPost]
        [Route("AddPublisher")]
        public async Task<IActionResult> AddPublisher(AddPublisherViewModel model)
        {
            bool userExist = await userService.ExistByEmailAsync(model.Email);

            if (!userExist)
            {
                TempData[ErrorMessage] = ErrorMessages.UnexistingUserByEmail;

                return View(model);
            }

            string userId = await this.userService.GetUserIdByEmailAsync(model.Email);

            bool isUserPublisher = await userService.IsUserPublisher(userId);

            if (isUserPublisher)
            {
                TempData[InformationMessage] = InformationMessages.UserIsPublisher;

                return RedirectToAction("All", "User");
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return View(model);
            }

            try
            {
                string publisherRoleId = await userService.GetPublisherRoleIdAsync();

                await userService.AddUserToRolePublisherAsync(userId, publisherRoleId);

                TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedPublisher;

                return RedirectToAction("All", "User");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return View(model);
            }
        }
    }
}

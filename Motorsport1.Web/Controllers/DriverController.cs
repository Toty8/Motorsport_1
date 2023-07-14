namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Article;
    using Motorsport1.Web.ViewModels.Driver;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class DriverController : BaseController
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllDriverViewModel> drivers = await this.driverService.AllAsync();

            return this.View(drivers);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                DriverDetailsViewModel viewmodel = await this.driverService.GetDetailsByIdAsync(id);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(All));
        }
    }
}

namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Article;
    using Motorsport1.Web.ViewModels.Driver;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using static Humanizer.In;

    public class DriverController : BaseController
    {
        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public DriverController(IDriverService driverService, ITeamService teamService)
        {
            this.driverService = driverService;
            this.teamService = teamService;
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

        [HttpGet]
        public async Task<IActionResult> AddOld()


        {
            bool isGridOfDriversFull = await this.driverService.IsGridOfDriversFull();

            if (isGridOfDriversFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction(nameof(All));
            }
            try
            {
                AddAndEditOldDriverViewModel model = new AddAndEditOldDriverViewModel();

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                var driver = await this.driverService.GetDriverForDeleteById(id);

                return this.View(driver);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DriverPreDeleteViewModel model, int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                await this.driverService.DeleteAsync(id);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }

            this.TempData[WarningMessage] = InformationMessages.InformationDeletedDriver;

            return RedirectToAction(nameof(All));
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(All));
        }
    }
}

namespace Motorsport1.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Draft;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using Motorsport1.Services.Data.Interfaces;

    public class DraftController : BaseAdminController
    {

        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public DraftController(IDriverService driverService, ITeamService teamService)
        {
            this.driverService = driverService;
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("Draft/EditDriver")]
        public async Task<IActionResult> EditDriver()
        {
            try
            {
                DraftEditDriverViewModel model = new DraftEditDriverViewModel();

                model.NamesAndPrices = await this.driverService.AllNamesWithPricesAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Draft/EditDriver")]
        public async Task<IActionResult> EditDriver(DraftEditDriverViewModel model)
        {
            bool exist = await this.driverService.ExistByIdAsync(model.Id);

            if (exist == false)
            {
                this.ModelState.AddModelError(nameof(model.Id), ErrorMessages.InvalidDriver);
            }

            if (!this.ModelState.IsValid)
            {
                model.NamesAndPrices = await this.driverService.AllNamesWithPricesAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.driverService.EditDraftPriceAsync(model.Price, model.Id);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedDriverDraftPrice;

            return this.RedirectToAction("Standing", "Draft", new { Area = "" });
        }

        [HttpGet]
        [Route("Draft/EditTeam")]
        public async Task<IActionResult> EditTeam()
        {
            try
            {
                DraftEditTeamViewModel model = new DraftEditTeamViewModel();

                model.NamesAndPrices = await this.teamService.AllNamesWithPricesAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Draft/EditTeam")]
        public async Task<IActionResult> EditTeam(DraftEditTeamViewModel model)
        {
            bool exist = await this.teamService.ExistByIdAsync(model.Id);

            if (exist == false)
            {
                this.ModelState.AddModelError(nameof(model.Id), ErrorMessages.InvalidTeam);
            }

            if (!this.ModelState.IsValid)
            {
                model.NamesAndPrices = await this.teamService.AllNamesWithPricesAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.teamService.EditDraftPriceAsync(model.Price, model.Id);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedTeamDraftPrice;

            return this.RedirectToAction("Standing", "Draft", new { Area = "" });
        }
    }
}

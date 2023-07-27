namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using Motorsport1.Web.ViewModels.Draft;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class DraftController : BaseController
    {

        private readonly IDraftService draftService;
        private readonly IDriverService driverService;

        public DraftController(IDraftService draftService, IDriverService driverService)
        {
            this.draftService = draftService;
            this.driverService = driverService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Standing()
        {
            IEnumerable<DraftAllViewModel> drafts = await this.draftService.StandingAsync();

            return this.View(drafts);
        }

        [HttpGet]
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
                return this.GeneralError(nameof(Standing));
            }
        }

        [HttpPost]
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

            return RedirectToAction(nameof(Standing));
        }

        [HttpGet]
        public async Task<IActionResult> EditTeam()
        {
            return this.Ok();
        }
    }
}

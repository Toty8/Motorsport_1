namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Draft;
    using Motorsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class DraftController : BaseController
    {

        private readonly IDraftService draftService;
        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public DraftController(IDraftService draftService, IDriverService driverService, ITeamService teamService)
        {
            this.draftService = draftService;
            this.driverService = driverService;
            this.teamService = teamService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Standing()
        {
            IEnumerable<DraftAllViewModel> drafts = await this.draftService.StandingAsync();

            return this.View(drafts);
        }

        [HttpGet]
        public async Task<IActionResult> Driver()
        {
            var isUserDrafted = await this.draftService.IsUserDraftedAsync(GetUserId());

            if (isUserDrafted)
            {
                this.TempData[ErrorMessage] = ErrorMessages.AlreadyDraftedUser;

                return RedirectToAction(nameof(Standing));
            }

            try
            {
                SelectDriverViewModel model = new SelectDriverViewModel();

                model.NamesAndPrices = await this.driverService.AllNamesWithPricesAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(nameof(Standing));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Driver(SelectDriverViewModel model)
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
                await this.draftService.SelectDriverAsync(model.Id, GetUserId());
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullySelectedDriver;

            return RedirectToAction(nameof(Team));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            var isUserDrafted = await this.draftService.IsUserDraftedAsync(GetUserId());

            if (isUserDrafted)
            {
                this.TempData[ErrorMessage] = ErrorMessages.AlreadyDraftedUser;

                return RedirectToAction(nameof(Standing));
            }

            var isThereSelectedDriver = await this.draftService.IsThereSelectedDriverAsync(GetUserId());

            if (!isThereSelectedDriver)
            {
                this.TempData[InformationMessage] = InformationMessages.SelectedDriverFirst;

                return RedirectToAction(nameof(Driver));
            }

            try
            {
                SelectTeamViewModel model = new SelectTeamViewModel();

                decimal budget = await this.draftService.GetBudgetLeftAsync(GetUserId());

                model.NamesAndPrices = await this.teamService.AllNamesWithPricesInRangeAsync(budget);

                model.BudgetLeft = budget.ToString("0.00");

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(nameof(Standing));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Team(SelectTeamViewModel model)
        {
            bool exist = await this.teamService.ExistByIdAsync(model.Id);

            if (exist == false)
            {
                this.ModelState.AddModelError(nameof(model.Id), ErrorMessages.InvalidTeam);
            }

            bool isTeamInactive = await this.driverService.DoesTeamHaveFreeSeatAsync(model.Id);

            if (isTeamInactive)
            {
                this.ModelState.AddModelError(nameof(model.Id), ErrorMessages.InactiveTeam);
            }

            decimal budget = await this.draftService.GetBudgetLeftAsync(GetUserId());

            bool isTeamPriceBiggerThenBudget = await this.teamService.IsTeamPriceBiggerThenBudgetAsync(model.Id, budget);

            if (isTeamPriceBiggerThenBudget)
            {
                this.TempData[ErrorMessage] = ErrorMessages.TeamIsTooExpencive;

                model.NamesAndPrices = await this.teamService.AllNamesWithPricesInRangeAsync(budget);

                model.BudgetLeft = budget.ToString("0.00");

                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                model.NamesAndPrices = await this.teamService.AllNamesWithPricesInRangeAsync(budget);

                model.BudgetLeft = budget.ToString("0.00");

                return this.View(model);
            }

            try
            {
                await this.draftService.SelectTeamAsync(model.Id, GetUserId());
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullySelectedTeam;

            return RedirectToAction(nameof(Standing));
        }

        [HttpPost]
        public async Task<IActionResult> Reset()
        {
            var isUserDrafted = await this.draftService.IsUserDraftedAsync(GetUserId());

            if (isUserDrafted)
            {
                this.TempData[ErrorMessage] = ErrorMessages.AlreadyDraftedUser;

                return RedirectToAction(nameof(Standing));
            }

            return RedirectToAction(nameof(Driver));
        }
    }
}

namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Driver;
    using Motorsport1.Web.ViewModels.Team;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class TeamController : BaseController
    {

        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllTeamsViewModel> teams = await this.teamService.AllAsync();

            return this.View(teams);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction(nameof(All));
            }

            bool isTeamActive = await this.teamService.DoesTeamHaveFreeSeat(id);

            if (isTeamActive == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InactiveTeam;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                TeamDetailsViewModel viewmodel = await this.teamService.GetDetailsByIdAsync(id);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFull();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.TeamsAreEnough;

                return this.RedirectToAction(nameof(All));
            }
            try
            {
                AddTeamViewModel model = new AddTeamViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamViewModel model)
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFull();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.TeamsAreEnough;

                return this.RedirectToAction(nameof(All));
            }

            bool teamExist = await this.teamService.ExistByNameAsync(model.Name);

            if (teamExist)
            {
                this.TempData[ErrorMessage] = ErrorMessages.ExistingTeamByName;

                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.teamService.AddAsync(model);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedTeam;

                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction(nameof(All));
            }
            try
            {
                var model = await this.teamService.GetTeamForEditById(id);

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTeamViewModel model, int id)
        {
            bool teamExist = await this.teamService.ExistByNameAsync(model.Name);

            if (teamExist)
            {
                this.TempData[ErrorMessage] = ErrorMessages.ExistingTeamByName;

                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.teamService.EditAsync(model, id);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedTeam;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction(nameof(All));
            }

            bool isTeamActive = await this.teamService.DoesTeamHaveFreeSeat(id);

            if (isTeamActive == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InactiveTeam;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                TeamPreDeleteViewModel viewmodel = await this.teamService.GetForDeleteById(id);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DriverPreDeleteViewModel model, int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction(nameof(All));
            }

            bool isTeamActive = await this.teamService.DoesTeamHaveFreeSeat(id);

            if (isTeamActive == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InactiveTeam;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                await this.teamService.DeleteAsync(id);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }

            this.TempData[InformationMessage] = InformationMessages.InformationUnactivatedTeam;

            return RedirectToAction(nameof(All));
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(All));
        }
    }
}

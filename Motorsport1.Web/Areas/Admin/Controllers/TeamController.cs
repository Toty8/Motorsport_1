namespace Motorsport1.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Driver;
    using Motorsport1.Web.ViewModels.Team;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using Motorsport1.Services.Data.Interfaces;

    public class TeamController : BaseAdminController
    {

        private readonly ITeamService teamService;
        private readonly IDriverService driverService;

        public TeamController(ITeamService teamService, IDriverService driverService)
        {
            this.teamService = teamService;
            this.driverService = driverService;
        }

        [HttpGet]
        [Route("Team/Add")]
        public async Task<IActionResult> Add()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.TeamsAreEnough;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }

            try
            {
                AddTeamViewModel model = new AddTeamViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Team/Add")]
        public async Task<IActionResult> Add(AddTeamViewModel model)
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
                await this.teamService.AddAsync(model);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        [HttpGet]
        [Route("Team/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }

            try
            {
                var model = await this.teamService.GetTeamForEditByIdAsync(id);

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Team/Edit/{id}")]
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

            return this.RedirectToAction("All", "Team", new { Area = "" });
        }

        [HttpGet]
        [Route("Team/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }

            bool isTeamInactive = await this.driverService.DoesTeamHaveFreeSeatAsync(id);

            if (isTeamInactive)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InactiveTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }

            try
            {
                TeamPreDeleteViewModel viewmodel = await this.teamService.GetForDeleteByIdAsync(id);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Team/Delete/{id}")]
        public async Task<IActionResult> Delete(DriverPreDeleteViewModel model, int id)
        {
            bool exist = await this.teamService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
            }

            bool isTeamInactive = await this.driverService.DoesTeamHaveFreeSeatAsync(id);

            if (isTeamInactive)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InactiveTeam;

                return this.RedirectToAction("All", "Team", new { Area = "" });
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

            return this.RedirectToAction("All", "Team", new { Area = "" });
        }
    }
}

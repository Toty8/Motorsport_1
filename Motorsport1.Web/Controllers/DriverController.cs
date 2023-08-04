namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Driver;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using Motorsport1.Web.Infrastructure.Extensions;

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
                return this.GeneralError("All");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddOld()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction(nameof(All));
            }

            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                AddOldDriverViewModel model = new AddOldDriverViewModel();

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddOld(AddOldDriverViewModel model)
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction(nameof(All));
            }

            bool driverExist = await this.driverService.ExistByNameAsync(model.Name);

            if (!driverExist)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriverByName;

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }

            bool teamExist = await this.teamService.ExistByIdAsync(model.TeamId);

            if (!teamExist)
            {
                this.ModelState.AddModelError(nameof(model.TeamId), ErrorMessages.InvalidTeam);
            }

            bool isThereAFreeSeat = await this.driverService.DoesTeamHaveFreeSeatAsync(model.TeamId);

            if (!isThereAFreeSeat)
            {
                this.ModelState.AddModelError(nameof(model.TeamId), ErrorMessages.FullTeam);
            }

            if (!this.ModelState.IsValid)
            {
                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.driverService.AddOldAsync(model);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedDriver;

                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);
                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddNew()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction(nameof(All));
            }

            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                AddNewDriverViewModel model = new AddNewDriverViewModel();

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(AddNewDriverViewModel model)
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction(nameof(All));
            }

            bool driverExist = await this.driverService.ExistByNameAsync(model.Name);

            if (driverExist)
            {
                this.TempData[ErrorMessage] = ErrorMessages.ExistingDriverByName;

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }

            bool driverNumberTaken = await this.driverService.IsThisNumberTakenAsync(model.Number);

            if (driverNumberTaken)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverNumberTaken;

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }

            if (model.Number == 1)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverIsnotCurrentChampion;

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }

            bool teamExist = await this.teamService.ExistByIdAsync(model.TeamId);

            if (!teamExist)
            {
                this.ModelState.AddModelError(nameof(model.TeamId), ErrorMessages.InvalidTeam);
            }

            bool isThereAFreeSeat = await this.driverService.DoesTeamHaveFreeSeatAsync(model.TeamId);

            if (!isThereAFreeSeat)
            {
                this.ModelState.AddModelError(nameof(model.TeamId), ErrorMessages.FullTeam);
            }

            if (!this.ModelState.IsValid)
            {
                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.driverService.AddNewAsync(model);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedDriver;

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
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction(nameof(All));
            }

            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                var teamId = await this.driverService.GetTeamIdByDriverIdAsync(id);

                var model = await this.driverService.GetDriverForEditByIdAsync(id, teamId);

                model.Teams = await this.teamService.AllTeamsAvailableAndDriversTeamAsync(teamId);

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDriverViewModel model, int id)
        {
            var currentDriverNumber = await this.driverService.GetNumberByIdAsync(id);

            bool driverNumberTaken = await this.driverService.IsThisNumberTakenAsync(model.Number);

            if (driverNumberTaken && model.Number != currentDriverNumber)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverNumberTaken;

                var teamId = await this.driverService.GetTeamIdByDriverIdAsync(id);

                model.Teams = await this.teamService.AllTeamsAvailableAndDriversTeamAsync(teamId);

                return this.View(model);
            }

            bool isDriverCurrentChamion = await this.driverService.IsDriverCurrentChampionAsync(id);

            if (isDriverCurrentChamion != true && model.Number == 1)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverIsnotCurrentChampion;

                var teamId = await this.driverService.GetTeamIdByDriverIdAsync(id);

                model.Teams = await this.teamService.AllTeamsAvailableAndDriversTeamAsync(teamId);

                return this.View(model);
            }

            bool teamExist = await this.teamService.ExistByIdAsync(model.TeamId);

            if (!teamExist)
            {
                this.ModelState.AddModelError(nameof(model.TeamId), ErrorMessages.InvalidTeam);
            }

            if (!this.ModelState.IsValid)
            {

                var teamId = await this.driverService.GetTeamIdByDriverIdAsync(id);

                model.Teams = await this.teamService.AllTeamsAvailableAndDriversTeamAsync(teamId);

                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.driverService.EditAsync(model, id);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedDriver;

            return RedirectToAction(nameof(Details), new { id });
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

            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(All));
            }

            try
            {
                var driver = await this.driverService.GetDriverForDeleteByIdAsync(id);

                return this.View(driver);
            }
            catch (Exception)
            {
                return this.GeneralError("All");
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

            this.TempData[InformationMessage] = InformationMessages.InformationUnactivatedDriver;

            return RedirectToAction(nameof(All));
        }
    }
}

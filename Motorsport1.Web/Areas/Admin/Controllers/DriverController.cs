namespace Motorsport1.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Driver;
    using Motorsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class DriverController : BaseAdminController
    {
        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public DriverController(IDriverService driverService, ITeamService teamService)
        {
            this.driverService = driverService;
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("Driver/AddOld")]
        public async Task<IActionResult> AddOld()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction("All", "Driver", new { Area = "" });
            }

            try
            {
                AddOldDriverViewModel model = new AddOldDriverViewModel();

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddOld(AddOldDriverViewModel model)
        {
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

                return this.RedirectToAction("All", "Driver", new { Area = "" });
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);
                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return this.View(model);
            }
        }

        [HttpGet]
        [Route("Driver/AddNew")]
        public async Task<IActionResult> AddNew()
        {
            bool isGridOfTeamsFull = await this.teamService.IsGridOfTeamsFullAsync();

            if (isGridOfTeamsFull)
            {
                this.TempData[ErrorMessage] = ErrorMessages.DriverAreEnough;

                return this.RedirectToAction("All", "Driver", new { Area = "" });
            }

            try
            {
                AddNewDriverViewModel model = new AddNewDriverViewModel();

                model.Teams = await this.teamService.AllTeamsAvailableAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(AddNewDriverViewModel model)
        {

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

                return this.RedirectToAction("All", "Driver", new { Area = "" });
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        [HttpGet]
        [Route("Driver/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction("All", "Driver", new { Area = "" });
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
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Driver/Edit/{id}")]
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

            return this.RedirectToAction("All", "Driver", new { Area = "" });
        }

        [HttpGet]
        [Route("Driver/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction("All", "Driver", new { Area = "" });
            }

            try
            {
                var driver = await this.driverService.GetDriverForDeleteByIdAsync(id);

                return this.View(driver);
            }
            catch (Exception)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Driver/Delete/{id}")]
        public async Task<IActionResult> Delete(DriverPreDeleteViewModel model, int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction("All", "Driver", new { Area = "" });
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

            return this.RedirectToAction("All", "Driver", new { Area = "" });
        }
    }
}

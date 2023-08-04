using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Standing;
using Mototsport1.Services.Data.Interfaces;
using static Motorsport1.Common.UIMessages;
using static Motorsport1.Common.NotificationMessageConstants;
using Motorsport1.Web.Infrastructure.Extensions;

namespace Motorsport1.Web.Controllers
{
    public class StandingController : BaseController
    {
        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public StandingController(IDriverService driverService, ITeamService teamService)
        {
            this.driverService = driverService;
            this.teamService = teamService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Drivers()
        {
            try
            {
                IEnumerable<DriversStandingViewModel> drivers = await this.driverService.StandingAsync();

                return this.View(drivers);
            }
            catch (Exception e)
            {
                return this.GeneralError("Drivers");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Teams()
        {
            try
            {
                IEnumerable<TeamStandingViewModel> teams = await this.teamService.StandingAsync();

                return this.View(teams);
            }
            catch (Exception e)
            {
                return this.GeneralError("Teams");
            }
        }

        [HttpGet]
        public IActionResult Reset()
        {
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(Drivers));
            }
            return this.View();
        }

        [HttpPost]
        [ActionName("Reset")]
        public async Task<IActionResult> ResetPost()
        {
            try
            {
                await this.driverService.ResetAsync();

                await this.teamService.ResetAsync();

                return this.RedirectToAction(nameof(Drivers));
            }
            catch (Exception e)
            {
                return this.GeneralError("Drivers");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddResult(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction(nameof(Drivers));
            }

            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = ErrorMessages.AccessDenied;

                return this.RedirectToAction(nameof(Drivers));
            }

            try
            {
                EditDriverStatisticsViewModel model = new EditDriverStatisticsViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(nameof(Drivers));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddResult(EditDriverStatisticsViewModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.driverService.EditDriverStatisticsAsync(model, id);

                await this.teamService.EditTeamStatisticsAsync(model, id);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
            this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAppliedStatistics;

            return RedirectToAction(nameof(Drivers));
        }
    }
}

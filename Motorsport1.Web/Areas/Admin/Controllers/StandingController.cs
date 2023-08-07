namespace Motorsport1.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Web.Infrastructure.Extensions;
    using Motorsport1.Web.ViewModels.Standing;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class StandingController : BaseAdminController
    {

        private readonly IDriverService driverService;
        private readonly ITeamService teamService;

        public StandingController(IDriverService driverService, ITeamService teamService)
        {
            this.driverService = driverService;
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("Standing/Reset")]
        public IActionResult Reset()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Reset")]
        [Route("Standing/Reset")]
        public async Task<IActionResult> ResetPost()
        {
            try
            {
                await this.driverService.ResetAsync();

                await this.teamService.ResetAsync();

                return this.RedirectToAction("Drivers", "Standing", new { Area = "" });
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpGet]
        [Route("Standing/AddResult/{id}")]
        public async Task<IActionResult> AddResult(int id)
        {
            bool exist = await this.driverService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingDriver;

                return this.RedirectToAction("Drivers", "Standing", new { Area = "" });
            }

            try
            {
                EditDriverStatisticsViewModel model = new EditDriverStatisticsViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError(null);
            }
        }

        [HttpPost]
        [Route("Standing/AddResult/{id}")]
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

            return this.RedirectToAction("Drivers", "Standing", new { Area = "" });
        }
    }
}

namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Team;
    using Motorsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class TeamController : BaseController
    {

        private readonly ITeamService teamService;
        private readonly IDriverService driverService;

        public TeamController(ITeamService teamService, IDriverService driverService)
        {
            this.teamService = teamService;
            this.driverService = driverService;
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

            bool isTeamInactive = await this.driverService.DoesTeamHaveFreeSeatAsync(id);

            if (isTeamInactive)
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
                return this.GeneralError("All");
            }
        }
    }
}

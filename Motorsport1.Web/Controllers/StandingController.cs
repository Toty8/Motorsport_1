

namespace Motorsport1.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Motorsport1.Web.ViewModels.Standing;
    using Motorsport1.Services.Data.Interfaces;

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
    }
}

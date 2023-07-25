using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Standing;
using Mototsport1.Services.Data.Interfaces;

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
            IEnumerable<DriversStandingViewModel> drivers = await this.driverService.StandingAsync();

            return this.View(drivers);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Teams()
        {
            IEnumerable<TeamStandingViewModel> teams = await this.teamService.StandingAsync();

            return this.View(teams);
        }
    }
}

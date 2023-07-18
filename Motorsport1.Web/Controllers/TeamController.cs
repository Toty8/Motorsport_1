using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Team;
using Mototsport1.Services.Data;
using Mototsport1.Services.Data.Interfaces;
using static Motorsport1.Common.UIMessages;

namespace Motorsport1.Web.Controllers
{
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

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(All));
        }
    }
}

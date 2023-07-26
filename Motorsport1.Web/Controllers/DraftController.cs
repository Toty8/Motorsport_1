using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Draft;
using Mototsport1.Services.Data.Interfaces;

namespace Motorsport1.Web.Controllers
{
    public class DraftController : BaseController
    {

        private readonly IDraftService draftService;

        public DraftController(IDraftService draftService)
        {
            this.draftService = draftService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Standing()
        {
            IEnumerable<DraftAllViewModel> drafts = await this.draftService.StandingAsync();

            return this.View(drafts);
        }
    }
}

namespace Motorsport1.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;
    using static Motorsport1.Common.UIMessages;

    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        protected IActionResult GeneralError(string? redirection)
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            if (redirection != null)
            {
                return this.RedirectToAction(nameof(redirection));
            }
            return this.RedirectToAction("Index", "Home");
        }
    }
}

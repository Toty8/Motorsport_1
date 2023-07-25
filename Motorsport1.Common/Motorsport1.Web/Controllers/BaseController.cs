namespace Motorsport1.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessageConstants;
    using static Common.UIMessages;

    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string id = String.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }

        protected IActionResult GeneralError(string redirection)
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction(nameof(redirection));
        }
    }
}

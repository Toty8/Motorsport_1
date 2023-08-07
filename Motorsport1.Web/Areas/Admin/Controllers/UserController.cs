namespace Motorsport1.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Web.ViewModels.User;

    public class UserController : BaseAdminController
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllAsync();

            return this.View(viewModel);
        }
    }
}

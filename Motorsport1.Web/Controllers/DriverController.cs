using Microsoft.AspNetCore.Mvc;
using Motorsport1.Web.ViewModels.Driver;
using Mototsport1.Services.Data.Interfaces;

namespace Motorsport1.Web.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllDriverViewModel> drivers = await this.driverService.AllAsync();

            return this.View(drivers);
        }
    }
}

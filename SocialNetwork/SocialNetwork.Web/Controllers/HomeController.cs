using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var statistics = await this.userService.GetStatistics();
            var indexView = new HomeIndexViewModel(statistics);

            return View(indexView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

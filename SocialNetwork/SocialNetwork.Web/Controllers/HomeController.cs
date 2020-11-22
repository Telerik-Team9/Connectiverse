using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;

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

        public async Task<IActionResult> GetNewsAsync()
        {
            // init with your API key
            var newsApiClient = new NewsApiClient("77114c2a46ee4aa781a1286afe5986a6");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Covid",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2020, 10, 25)
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                return Ok(articlesResponse);
            }

            return BadRequest();
        }

/*        // total results found
        Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(JsonConvert.SerializeObject(article));
                    Console.WriteLine();
                }*/

}
}

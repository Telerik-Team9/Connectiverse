using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;

namespace SocialNetwork.Web.ViewComponents
{
    public class NewsbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
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
                return View(articlesResponse);
            }

            return View();
        }
    }
}

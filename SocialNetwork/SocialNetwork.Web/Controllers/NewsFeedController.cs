using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Controllers
{
    public class NewsFeedController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public NewsFeedController(IUserService userService, IPostService postService, UserManager<User> userManager, IMapper mapper)
        {
            this.userService = userService;
            this.postService = postService;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        // GET: NewsFeedController
        public async Task<ActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(User);

            var feed = await this.postService.GetUserFriendsPostsAsync(user.Id);
            var result = new NewsFeedViewModel { Posts = feed.Select(this.mapper.Map<PostViewModel>).ToHashSet() };
            //var result = feed.Select(this.mapper.Map<PostViewModel>);

            return View(result);
        }

        // GET: NewsFeedController/Details/5
        //  public ActionResult Details(int id)
        //{
        //    return View();
        //}
        //
        //  // GET: NewsFeedController/Create
        //  public ActionResult Create()
        //{
        //    return View();
        //}
        //
        //  // POST: NewsFeedController/Create
        //  [HttpPost]
        //  [ValidateAntiForgeryToken]
        //  public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //
        //  // GET: NewsFeedController/Edit/5
        //  public ActionResult Edit(int id)
        //{
        //    return View();
        //}
        //
        //  // POST: NewsFeedController/Edit/5
        //  [HttpPost]
        //  [ValidateAntiForgeryToken]
        //  public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //
        //  // GET: NewsFeedController/Delete/5
        //  public ActionResult Delete(int id)
        //{
        //    return View();
        //}
        //
        //  // POST: NewsFeedController/Delete/5
        //  [HttpPost]
        //  [ValidateAntiForgeryToken]
        //  public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        // GET: AccountController
        [HttpGet]
        public async Task<ActionResult> Profile()
        {
            var loggedinUsr = await this.userManager.GetUserAsync(User);

            var user = await this.userService.GetByIdAsync(loggedinUsr.Id);
            var result = this.mapper.Map<UserViewModel>(user);
            result.Posts = result.Posts
                .OrderByDescending(p => p.CreatedOn)
                .ToList();

            return View(result);
        }

        [HttpGet("friendId")]
        public async Task<ActionResult> FriendProfile(Guid userId)
        {
            var signedIn = await this.userManager.GetUserAsync(User);

            var user = await this.userService.GetByIdAsync(userId);

            var loggedUser = await this.userService.GetByIdAsync(signedIn.Id);

            var result = this.mapper.Map<UserViewModel>(user);

            result.Posts = result.Posts
                .OrderByDescending(p => p.CreatedOn)
                .ToList();

            result.IsFriendshipRequested = loggedUser.FriendRequests
                .Any(r => r.SenderId == loggedUser.Id && r.ReceiverId == result.Id && !r.IsDeleted);

            return View(result);
        }

        public async Task<ActionResult> FriendRequests()
        {
            var user = await this.userManager.GetUserAsync(User);

            var friendRequests = await this.userService.GetAllFriendRequestsReceivedAsync(user.Id);

            var result = friendRequests.Select(this.mapper.Map<FriendRequestViewModel>);

            return View(result);
        }

        public async Task<ActionResult> ChangeFriendshipStatus(Guid userId,
            Guid friendId, string type)
        {
            try
            {
                if (type == "add") //Ready not tested
                {
                    await this.userService.SendFriendRequestAsync(userId, friendId);
                }
                else if (type == "accept") //Ready and tested
                {
                    await this.userService.AcceptFriendRequestAsync(friendId, userId);
                }
                else if (type == "remove") //Readey not tested
                {
                    await this.userService.RemoveFriendAsync(userId, friendId);
                }
                return this.Ok();
            }
            catch (Exception)
            {
                return this.RedirectToAction("Error", "Home");
            }
        }

        // GET: AccountController/Details/5
        /*        public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: AccountController/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: AccountController/Create
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: AccountController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: AccountController/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: AccountController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: AccountController/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}

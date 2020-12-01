using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System;
using SocialNetwork.Models.Common.Enums;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

            result.Posts.Add(new PostViewModel()
            {
                file = new FormFile(default, default, default, default, default)
            });

            ViewData["visibility"] = Enum.GetValues(typeof(Visibility));

            return View(result);
        }

        [HttpGet("friendId")]
        public async Task<ActionResult> FriendProfile(Guid userId)
        {
            var signedIn = await this.userManager.GetUserAsync(User);

            if (userId == signedIn.Id)
            {
                return this.RedirectToAction("Profile", "Account");
            }

            var user = await this.userService.GetByIdAsync(userId);

            var loggedUser = await this.userService.GetByIdAsync(signedIn.Id);

            var result = this.mapper.Map<UserViewModel>(user);

            var areFriends = loggedUser.Friends
                .FirstOrDefault(f => f.UserFriendId == userId) == null
                ? false : true;

            if (areFriends)
            {
                result.Posts = result.Posts
                    .Where(p => p.Visibility != Visibility.OnlyMe)
                    .OrderByDescending(p => p.CreatedOn)
                    .ToList();
            }
            else
            {
                result.Posts = result.Posts
                    .Where(p => p.Visibility == Visibility.Public)
                    .OrderByDescending(p => p.CreatedOn)
                    .ToList();
            }

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
                if (type == "add") 
                {
                    await this.userService.SendFriendRequestAsync(userId, friendId);
                }
                else if (type == "accept") 
                {
                    await this.userService.AcceptFriendRequestAsync(friendId, userId);
                }
                else if (type == "remove")
                {
                    await this.userService.RemoveFriendAsync(userId, friendId);
                }
                else if (type == "decline")
                {
                    await this.userService.DeleteFriendRequestAsync(friendId, userId);
                }
                return this.RedirectToAction("FriendProfile", new { userId = friendId });
            }
            catch (Exception)
            {
                return this.RedirectToAction("Error", "Home");
            }
        }
    }
}

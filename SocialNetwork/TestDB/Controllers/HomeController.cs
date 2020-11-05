using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using TestDB.Models;

namespace TestDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService countryService;
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly IFriendService friendService;
        private readonly ILikeService likeService;
        private readonly ITownService townService;

        public HomeController(ILogger<HomeController> logger
            , ICountryService countryService
            , IUserService userService
            , IPostService postService
            , ICommentService commentService,
            IFriendService friendService,
            ILikeService likeService,
            ITownService townService)
        {
            _logger = logger;
            this.countryService = countryService;
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.friendService = friendService;
            this.likeService = likeService;
            this.townService = townService;
        }

        public async Task<IActionResult> Index()
        {
            //var result = this.countryService.Get(1);
            //var result = this.userService.GetAll();
            //var result = this.postService.GetAll();
            //var result = this.commentService.GetAll();
            //var result = this.commentService.GetById(1);
            //var result = this.friendService.GetById(1);
            //var result = this.userService.GetAllFriendRequestsSent(Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"));
            //var result = this.likeService.GetPostLikes(1);
            //var result = this.userService.CreateSocialMedia(default);
            /*            var ImageDTO = new PhotoDTO
                        {
                            Url = "NEWPHOTO2",
                        };

                        var postDTO = new PostDTO
                        {
                            Content = "new frsh content 11dasdasdas",
                            UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                            UserDisplayName = "Magi Nikolova",
                            UserProfilePictureUrl = "dsadasds"
                        };

                        var result = await this.postService.CreateAsync(postDTO);*/

            var result = await this.postService.GetUserFriendsPostsAsync(Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"));


/*            var likeDTO = new LikeDTO
            {
                UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                UserDisplayName = "Magi Nikolova",
                PostId = 1
            };
            var result = await this.likeService.CreateAsync(likeDTO);*/
            //var result = await this.townService.GetAllAsync();




            return View();
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

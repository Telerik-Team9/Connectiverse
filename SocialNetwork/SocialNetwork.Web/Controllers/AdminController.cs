using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public AdminController(IUserService userService,
            IPostService postService,
            ICommentService commentService,
            IMapper mapper)
        {
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var users = await this.userService.GetAllAsync();
            var result = users.Select(this.mapper.Map<UserViewModel>)
                              .OrderBy(u => u.DisplayName);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> ListPosts()
        {
            var posts = await this.postService.GetAllAsync();
            var result = posts.Select(this.mapper.Map<PostViewModel>)
                              .OrderByDescending(p => p.CreatedOn);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> ListComments()
        {
            var comments = await this.commentService.GetAllAsync();
            var result = comments.Select(this.mapper.Map<CommentViewModel>)
                                 .OrderByDescending(p => p.CreatedOn);

            return View(result);
        }
    }
}

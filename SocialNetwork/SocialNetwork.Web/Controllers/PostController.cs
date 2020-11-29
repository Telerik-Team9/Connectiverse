using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Models;
using SocialNetwork.Models.Common.Enums;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Hubs;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHubContext<ChatHub> hubContext;

        public PostController(IUserService userService,
            IPostService postService,
            ICommentService commentService,
            ILikeService likeService,
            UserManager<User> userManager,
            IMapper mapper,
            IHubContext<ChatHub> hubContext)
        {
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.likeService = likeService;
            this.userManager = userManager;
            this.mapper = mapper;
            this.hubContext = hubContext;
        }

        // GET: FeedController/NewsFeed
        public async Task<ActionResult> NewsFeed()
        {
            var user = await this.userManager.GetUserAsync(User);

            var feed = await this.postService.GetUserFriendsPostsAsync(user.Id);

            var posts = new List<PostCommentViewModel>();

            foreach (var item in feed)
            {
                var posViewModel = this.mapper.Map<PostViewModel>(item);
                var postCommentModel = new PostCommentViewModel()
                {
                    Post = posViewModel,
                    NewComment = new CommentViewModel()
                };
                posts.Add(postCommentModel);
            }

            var result = posts.Where(x => x.Post.Visibility != Visibility.OnlyMe)
                              .OrderByDescending(x => x.Post.CreatedOn)
                              .ToList();
            return View(result);
        }

        // GET: FeedController/Search
        [HttpGet]
        public ActionResult Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                if (model.SearchCriteria.ToLower() == "users")
                {
                    List<UserDTO> users = new List<UserDTO>();

                    if (model.SearchWord == null)
                    {
                        var allUsers = await this.userService.GetAllAsync();
                        users = allUsers.OrderBy(u => u.DisplayName).ToList();
                    }
                    else
                    {
                        var foundUsers = await this.userService.GetByUserNameAsync(model.SearchWord, model.SortOrder);
                        users = foundUsers.ToList();
                    }

                    var searchModel = new SearchViewModel
                    {
                        Users = users
                               .Select(this.mapper.Map<UserSearchViewModel>)
                               .ToList()
                    };

                    return View(searchModel);
                }
                else if (model.SearchCriteria.ToLower() == "posts")
                {
                    var result = await this.postService.GetByContentAsync(model.SearchWord, model.SortOrder);

                    //  if (!result.Any())
                    //  {
                    //      return this.NotFound();
                    //  }

                    var searchModel = new SearchViewModel
                    {
                        Posts = result
                               .Select(this.mapper.Map<PostViewModel>)
                               .ToList()
                    };

                    return View(searchModel);
                }
            }
            catch
            {
                return RedirectToAction("Search");
            }
            //Remove this.
            return Ok();
        }

        // Remove/update/modify
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel postViewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var postDTO = this.mapper.Map<PostDTO>(postViewModel);
                postDTO.UserId = user.Id;

                var result = await this.postService.CreateAsync(postDTO, postViewModel.file);

                return RedirectToAction("Profile", "Account");
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ChangeProfilePhoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfilePhoto(PostViewModel postViewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var result = await this.postService.ChangeDisplayPicture(postViewModel.file, user.Id, "profile");

                return RedirectToAction("Profile", "Account");
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeCoverPhoto(PostViewModel postViewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var result = await this.postService.ChangeDisplayPicture(postViewModel.file, user.Id, "cover");

                return RedirectToAction("Profile", "Account");
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Comment(PostCommentViewModel viewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var comment = this.mapper.Map<CommentDTO>(viewModel.NewComment);
                comment.UserId = user.Id;

                await this.commentService.CreateAsync(comment); // TODO: Do we need to get the new comment?

                return this.Redirect("NewsFeed");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Like(int postId, bool isLiked)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);
                var postDTO = await this.postService.GetPostByIdAsync(postId);
                postDTO.UserId = user.Id;

                var likes = postDTO.Likes.Count;

                var likeDislike = isLiked
                    ? await this.likeService.DislikeAsync(postDTO)
                    : await this.likeService.LikeAsync(postDTO);

                likes = isLiked ? likes - 1 : likes + 1;

                await this.hubContext.Clients.All.SendAsync("Test", postDTO.Id, likes);
                return this.Ok();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
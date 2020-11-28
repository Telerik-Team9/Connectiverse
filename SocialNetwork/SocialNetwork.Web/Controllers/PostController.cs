﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Models.Common.Enums;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
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

        public PostController(IUserService userService,
            IPostService postService,
            ICommentService commentService,
            ILikeService likeService,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.likeService = likeService;
            this.userManager = userManager;
            this.mapper = mapper;
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
        public async Task<IActionResult> Like([FromBody] PostCommentViewModel viewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);
                var postDTO = await this.postService.GetPostByIdAsync(viewModel.PostId);
                postDTO.UserId = user.Id;

                var likeDislike = viewModel.isLiked ? await this.likeService.DislikeAsync(postDTO)
                    : await this.likeService.LikeAsync(postDTO);

                return this.Ok();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
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
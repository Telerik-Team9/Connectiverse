using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public PostController(IUserService userService,
            IPostService postService,
            ICommentService commentService,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        // GET: FeedController/NewsFeed
        public async Task<ActionResult> NewsFeed()
        {
            var user = await this.userManager.GetUserAsync(User);

            var feed = await this.postService.GetUserFriendsPostsAsync(user.Id);

            var das = new List<PostCommentViewModel>();

            foreach (var item in feed)
            {
                var posViewModel = this.mapper.Map<PostViewModel>(item);
                var postCommentModel = new PostCommentViewModel()
                {
                    Post = posViewModel,
                    NewComment = new CommentViewModel()
                };
                das.Add(postCommentModel);
            }
            //var result = new NewsFeedViewModel { Posts = feed.Select(this.mapper.Map<PostViewModel>).ToHashSet() };
            //var result = feed.Select(this.mapper.Map<PostViewModel>);

            return View(das);
        }

        // GET: FeedController/Search
        public ActionResult Search()
        {
            return View();
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

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Comment(PostCommentViewModel postCommentViewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var comment = this.mapper.Map<CommentDTO>(postCommentViewModel.NewComment);
                comment.UserId = user.Id;

                await this.commentService.CreateAsync(comment); // TODO: Do we need to get the new comment?

                return RedirectToAction("Profile", "Account");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
            /*            try
                        {
                            var user = await this.userManager.GetUserAsync(User);

                            var mapped = this.mapper.Map<PostDTO>(postViewModel);
                            mapped.UserId = user.Id;

                            //var result = await this.postService.CreatePostAsync(postViewModel.file, mapped);

                            return RedirectToAction("Index", "Home");
                        }
                        catch (Exception)
                        {
                            return this.BadRequest();
                        }*/
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
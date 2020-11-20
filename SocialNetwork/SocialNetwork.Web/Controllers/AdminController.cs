using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;
using System;
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

        public async Task<IActionResult> ListUsers()
        {
            var users = await this.userService.GetAllAsync();
            var result = users.Select(this.mapper.Map<UserViewModel>)
                              .OrderBy(u => u.DisplayName);

            return View(result);
        }
        public async Task<IActionResult> ListPosts()
        {
            var posts = await this.postService.GetAllAsync();
            var result = posts.Select(this.mapper.Map<PostViewModel>)
                              .OrderByDescending(p => p.CreatedOn);

            return View(result);
        }
        public async Task<IActionResult> ListComments()
        {
            var comments = await this.commentService.GetAllAsync();
            var result = comments.Select(this.mapper.Map<CommentViewModel>)
                                 .OrderByDescending(p => p.CreatedOn);

            return View(result);
        }


        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var delete = await this.postService.DeletePostAsync(id);
                return RedirectToAction("ListPosts", "Admin");
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var delete = await this.commentService.DeleteAsync(id);
                return RedirectToAction("ListComments", "Admin");
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult EditPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostViewModel model)
        {
            try
            {
                var postDTO = this.mapper.Map<PostDTO>(model);
                var result = await this.postService.EditPostAsync(postDTO);

                return RedirectToAction("ListPosts", "Admin");
            }
            catch
            {
                return BadRequest();
            }
        }


        public IActionResult EditComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(CommentViewModel model)
        {
            try
            {
                var commentDTO = this.mapper.Map<CommentDTO>(model);
                var result = await this.commentService.EditAsync(commentDTO);

                return RedirectToAction("ListComments", "Admin");
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            bool isDeleted = await this.userService.DeleteAsync(userId);

            if (isDeleted)
            {
                return RedirectToAction("ListUsers");
            }

            return BadRequest();
        }

    }
}

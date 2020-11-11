﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public UsersController(SignInManager<User> signInManager,
                                UserManager<User> userManager,
                                IUserService userService,
                                IPostService postService,
                                ITokenService tokenService,
                                IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
            this.postService = postService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid post.");
            }
            //map user id later...
            var postDTO = this.mapper.Map<PostDTO>(model);
            //postDTO.UserId = usermanager.GetUserId();
            var result = await this.postService.CreateAsync(postDTO);

            if (result == null)
            {
                return this.BadRequest("Something went wrong.");
            }

            return this.Created("post", this.mapper.Map<PostModel>(result));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUsersProfileInfo(Guid id)
        {
            var userDTO = await this.userService.GetByIdAsync(id);

            var userProfile = this.mapper.Map<UserProfileInfoModel>(userDTO);

            if (userProfile == null)
            {
                return this.NotFound();
            }

            return Ok(userProfile);
        }

        [HttpGet("getfriends/{id}")]
        public async Task<IActionResult> GetFriends(Guid id)
        {
            var friends = await this.userService.GetFriendsAsync(id);

            if (!friends.Any())
            {
                return this.NotFound();
            }

            var friendsModels = friends.Select(this.mapper.Map<UserProfileInfoModel>);

            return this.Ok(friendsModels);
        }

        [HttpGet("getnewsfeed/{id}")]
        public async Task<IActionResult> GetNewsfeed(Guid id)
        {
            //throw new NotImplementedException();

            var newsfeed = await this.postService.GetUserFriendsPostsAsync(id);

            if (!newsfeed.Any())
            {
                return this.NotFound();
            }

            var friendsModels = newsfeed.Select(this.mapper.Map<PostModel>);

            return this.Ok(friendsModels);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO model)
        {
            //TODO: Optimize
            var signInResult = await signInManager
                   .PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return this.BadRequest(new { message = "Username or password is incorrect" });
            }

            //var user = await this.userManager.GetUserAsync(User);
            //var user = await this.userManager.FindByNameAsync(model.UserName);
            // model.Token = this.tokenService.CreateToken(user);

            var user = await this.userManager.Users
                .Include(p => p.Town).ThenInclude(t => t.Country)
                .Include(u => u.SocialMedias)
                .SingleOrDefaultAsync(x => x.UserName == model.UserName.ToLower());

            var userDTO = this.mapper.Map<UserDTO>(user);
            userDTO.Token = this.tokenService.CreateToken(user);

            return this.Ok(userDTO);
        }

    }
}
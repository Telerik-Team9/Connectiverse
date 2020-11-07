using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(SignInManager<User> signInManager,
                               UserManager<User> userManager,
                               IUserService userService,
                               IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUsersProfileInfo(Guid id)
        {
            var userDTO = await this.userService.GetByIdAsync(id);

            var userProfile = this.mapper.Map<UserProfileInfoModel>(userDTO);
            var town = userProfile.Town;
            if (userProfile == null)
            {
                return this.NotFound();
            }

            return Ok(userProfile);
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginCredentialsModel model)
        {
            // TODO : Implement
            return View();
        }
    }
}

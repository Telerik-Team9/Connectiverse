using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;

namespace SocialNetwork.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IChatService chatService;

        public ChatController(UserManager<User> userManager, IChatService chatService)
        {
            this.userManager = userManager;
            this.chatService = chatService;
        }

        public async Task<IActionResult> Messenger()
        {
            var user = await this.userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = user.DisplayName;
            var messanges = await this.chatService.GetAllMessagesAsync();

            return View();
        }

        public async Task<IActionResult> Create(Message message)
        {
            var user = await this.userManager.GetUserAsync(User);
            message.UserName = user.DisplayName;
            message.UserId = user.Id;

            var result = await this.chatService.CreateMessageAsync(message);

            if(result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

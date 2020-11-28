using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Hubs;

namespace SocialNetwork.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IChatService chatService;
        private readonly IHubContext<ChatHub> chatHub;

        public ChatController(UserManager<User> userManager, IChatService chatService, IHubContext<ChatHub> chatHub)
        {
            this.userManager = userManager;
            this.chatService = chatService;
            this.chatHub = chatHub;
        }

        public async Task<IActionResult> Messenger()
        {
            var user = await this.userManager.GetUserAsync(User);
            ViewBag.CurrUserId = user.Id;
            ViewBag.CurrUserName = user.DisplayName;
            ViewBag.CurrUserProfilePictureUrl = user.ProfilePictureUrl;

            var messanges = await this.chatService.GetAllMessagesAsync();

            return View(messanges);
        }

        public async Task<IActionResult> Create(string input, string userId, string userName, string userProfilePictureUrl)
        {
            //var user = await this.userManager.GetUserAsync(User);
            var message = new Message();
            message.Text = input;

            message.UserId = Guid.Parse(userId);
            message.UserName = userName;
            message.UserProfilePictureUrl = userProfilePictureUrl;

            var result = await this.chatService.CreateMessageAsync(message);

            if (result == false)
            {
                return BadRequest();
            }

            ViewBag.CurrUserName = message.UserName;
            ViewBag.userProfilePictureUrl = message.UserProfilePictureUrl;

            await this.chatHub.Clients.All.SendAsync("receiveMessage", input, userName, userProfilePictureUrl);

            return Ok();
        }
    }
}

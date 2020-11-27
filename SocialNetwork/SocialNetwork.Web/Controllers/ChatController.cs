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
            ViewBag.CurrentUserName = user.DisplayName;

            var messanges = await this.chatService.GetAllMessagesAsync();

            return View(messanges);
        }

        public async Task<IActionResult> Create(string input)
        {
            var user = await this.userManager.GetUserAsync(User);
            var message = new Message();
            message.Text = input;

            message.UserName = user.DisplayName;
            message.UserId = user.Id;

            var result = await this.chatService.CreateMessageAsync(message);


            if (result == false)
            {
                return BadRequest();
            }

            await this.chatHub.Clients.All.SendAsync("receiveMessage", input);

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.Hubs;

namespace SocialNetwork.Web.ViewComponents
{
    public class ChatViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;
        private readonly IChatService chatService;
        private readonly IHubContext<ChatHub> chatHub;

        public ChatViewComponent(UserManager<User> userManager, IChatService chatService, IHubContext<ChatHub> chatHub)
        {
            this.userManager = userManager;
            this.chatService = chatService;
            this.chatHub = chatHub;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
/*            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            ViewBag.CurrentUserName = user.DisplayName;*/

            var messanges = await this.chatService.GetAllMessagesAsync();

            return View(messanges);
        }
    }
}

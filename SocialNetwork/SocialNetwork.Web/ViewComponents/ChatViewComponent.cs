using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.Services.Contracts;
using System.Threading.Tasks;

namespace SocialNetwork.Web.ViewComponents
{
    public class ChatViewComponent : ViewComponent
    {
        private readonly IChatService chatService;
        public ChatViewComponent(IChatService chatService)
        {
            this.chatService = chatService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messanges = await this.chatService.GetAllMessagesAsync();
            return View(messanges);
        }
    }
}

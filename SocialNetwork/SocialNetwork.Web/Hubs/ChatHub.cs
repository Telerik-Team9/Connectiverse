using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
            => await Clients.All.SendAsync("receiveMessage", message);
    }
}

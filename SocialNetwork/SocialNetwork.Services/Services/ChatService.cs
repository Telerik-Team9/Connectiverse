using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly SocialNetworkDBContext context;

        public ChatService(SocialNetworkDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            var messages = await this.context.Messages.ToListAsync();

            return messages;
        }

        public async Task<bool> CreateMessageAsync(Message message)
        {
            try
            {
                await this.context.Messages.AddAsync(message);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

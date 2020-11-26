using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IChatService
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<bool> CreateMessageAsync(Message message);
    }
}

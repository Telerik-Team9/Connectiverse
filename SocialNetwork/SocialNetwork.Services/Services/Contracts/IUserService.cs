using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> DeleteAsync(Guid userId);
        Task<bool> IsLegitAsync(string userEmail);
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model);
        Task<FriendRequestDTO> SendFriendRequestAsync(Guid senderId, Guid receiverId);
        Task<bool> RemoveFriendAsync(Guid userId, Guid userFriendId);
        Task<bool> DeleteFriendRequestAsync(Guid senderId, Guid receiverId);
        Task<bool> AcceptFriendRequestAsync(Guid senderId, Guid receiverId);
        Task<bool> AreFriendsAsync(Guid senderId, Guid receiverId);
        Task<IEnumerable<UserDTO>> GetByUserNameAsync(string searchCriteria = "", string sortOrder = "nameAsc");
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid id);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid id);
        Task<(int, int, int, int)> GetStatistics();
    }
}

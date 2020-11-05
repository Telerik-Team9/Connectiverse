using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IUserService
    {
        // Create ?
        Task<UserDTO> GetByIdAsync(Guid id);
        // Update ?
        // Delete ?
        Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model);
        Task<FriendRequestDTO> SendFriendRequestAsync(Guid receiverId);    // API
        Task<bool> AddFriendAsync(Guid senderid, Guid receiverid);
        Task<bool> RemoveFriendAsync(Guid id);
        Task<bool> DeleteFriendRequestAsync(Guid receiverId);
        Task<bool> AcceptFriendRequestAsync(Guid receiverId);

        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid userId);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid userId);
        //IEnumerable<FriendDTO> GetFriendRequests(Guid id); TODO: Profile info DTO
    }
}

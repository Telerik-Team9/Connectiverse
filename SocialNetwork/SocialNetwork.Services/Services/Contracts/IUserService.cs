using Microsoft.AspNetCore.Identity;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IUserService
    {
        // Create ?
        public UserManager<User> UserManager { get; }
        Task<UserDTO> GetByIdAsync(Guid id);
        // Update ?
        // Delete ?
        Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model);
        Task<FriendRequestDTO> SendFriendRequestAsync(Guid senderId, Guid receiverId);    // API
        Task<bool> AddFriendAsync(Guid userId, Guid userFriendId);
        Task<bool> RemoveFriendAsync(Guid userId, Guid userFriendId);
        Task<bool> DeleteFriendRequestAsync(Guid senderId, Guid receiverId);
        Task<bool> AcceptFriendRequestAsync(Guid senderId, Guid receiverId);

        Task<IEnumerable<UserDTO>> GetByUserNameAsync(string searchCriteria = "");
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid id);
        Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid id);
        //IEnumerable<FriendDTO> GetFriendRequests(Guid id); TODO: Profile info DTO
    }
}

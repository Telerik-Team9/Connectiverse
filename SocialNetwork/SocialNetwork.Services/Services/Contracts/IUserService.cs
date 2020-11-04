using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IUserService
    {
        // Create ?
        UserDTO GetById(Guid id);
        // Update ?
        // Delete ?

        bool AddFriend(Guid id);
        bool RemoveFriend(Guid id);
        FriendRequestDTO SendFriendRequest(Guid receiverId);    // API
        bool DeleteFriendRequest(Guid receiverId);
        bool AcceptFriendRequest(Guid receiverId);

        IEnumerable<UserDTO> GetAll();
        IEnumerable<FriendDTO> GetFriends(Guid id);
        IEnumerable<FriendDTO> GetFriendRequests(Guid id);
        IEnumerable<FriendRequestDTO> GetAllFriendRequestsSent(Guid userId);
        IEnumerable<FriendRequestDTO> GetAllFriendRequestsReceived(Guid userId);
        //IEnumerable<FriendDTO> GetFriendRequests(Guid id); TODO: Profile info DTO
    }
}

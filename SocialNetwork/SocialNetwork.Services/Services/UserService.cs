using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Services.Services
{
    public class UserService : IUserService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;
        //TODO: Inject USerManager

        public UserService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AcceptFriendRequest(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public bool AddFriend(Guid id)
        {
            throw new NotImplementedException();
        }

        public SocialMediaDTO CreateSocialMedia(SocialMediaDTO dto)
        {
            var sm = this.context.SocialMedias
                         .Include(x => x.User)
                         .First();

            var rslt = this.mapper.Map<SocialMediaDTO>(sm);

            return rslt;
        }

        public bool DeleteFriendRequest(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        /*        public IEnumerable<UserDTO> GetAll()
                {
                    var users = this.context.Users
                                    .Include(u => u.Town).ThenInclude(t => t.Country)
                                    .Include(u => u.Friends)
                                    .Include(u => u.FriendRequests)
                                    .Include(u => u.Posts)
                                    .Include(u => u.SocialMedias)
                                    .Include(u => u.Likes)
                                    .Include(u => u.Comments);

                    var result = users.Select(this.mapper.Map<UserDTO>);
                    return result;
                }*/

        public IEnumerable<FriendRequestDTO> GetAllFriendRequestsReceived(Guid userId)
        {
            throw new NotImplementedException();
        }

        /*        public IEnumerable<LikeDTO> GetAllFriendRequestsSent(Guid userId)
        {
            var friendRequests = this.context.FriendRequests
                                     .Include(fr => fr.Sender)
                                     .Include(fr => fr.Receiver)
                                     .Where(fr => fr.SenderId == userId);

            var DTOs = friendRequests.Select(this.mapper.Map<FriendRequestDTO>);

            return DTOs;
        }*/



        // READY
        /*        public IEnumerable<FriendRequestDTO> GetAllFriendRequestsSent(Guid userId)
                {
                    var friendRequests = this.context.FriendRequests
                                             .Include(fr => fr.Sender)
                                             .Include(fr => fr.Receiver)
                                             .Where(fr => fr.SenderId == userId);

                    var DTOs = friendRequests.Select(this.mapper.Map<FriendRequestDTO>);

                    return DTOs;
                }*/

        public UserDTO GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendDTO> GetFriendRequests(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendDTO> GetFriends(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(Guid id)
        {
            throw new NotImplementedException();
        }

        public FriendRequestDTO SendFriendRequest(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<FriendRequestDTO> IUserService.GetAllFriendRequestsSent(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

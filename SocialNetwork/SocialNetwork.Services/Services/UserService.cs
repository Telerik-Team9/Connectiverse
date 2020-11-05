using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<bool> AcceptFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddFriendAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendDTO>> GetFriendRequestsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendDTO>> GetFriendsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFriendAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FriendRequestDTO> SendFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }

/*        public SocialMediaDTO CreateSocialMedia(SocialMediaDTO dto)
        {
            var sm = this.context.SocialMedias
                         .Include(x => x.User)
                         .First();

            var rslt = this.mapper.Map<SocialMediaDTO>(sm);

            return rslt;
        }*/

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
    }
}

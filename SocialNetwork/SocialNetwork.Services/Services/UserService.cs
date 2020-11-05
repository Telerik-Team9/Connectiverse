using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Constants;
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

        public async Task<bool> AddFriendAsync(Guid senderId, Guid receiverId)
        {
            var friendship1 = new Friend
            {
                UserId = senderId,
                UserFriendId = receiverId
            };
            var friendship2 = new Friend
            {
                UserId = receiverId,
                UserFriendId = senderId
            };

            await this.context.Friends.AddRangeAsync(friendship1, friendship2);
            await this.context.SaveChangesAsync();

            return true;
        }

        public Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await this.context.Users
                                  .Where(u => !u.IsDeleted)
                                  .ToListAsync();

            if (!users.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return users.Select(this.mapper.Map<UserDTO>);
        } // Ready

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

        public async Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id)
        {
            var friendships = await this.context.Friends
                .Where(f => f.UserId == id)
                .ToListAsync();

            var friends = new List<User>();

            foreach (var fs in friendships)
            {
                var friend = await this.context.Users
                                       .Include(u => u.Town)
                                       .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == fs.UserFriendId);
                friends.Add(friend);
            }

            return friends.Select(this.mapper.Map<UserDTO>);
        }

        public Task<bool> RemoveFriendAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FriendRequestDTO> SendFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }
    }
}

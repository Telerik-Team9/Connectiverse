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

        public async Task<bool> AddFriendAsync(Guid userId, Guid userFriendId)
        {
            var friendship = await this.context.Friends
                .FirstOrDefaultAsync(f => f.UserId == userId && f.UserFriendId == userFriendId);

            if (friendship != null && friendship.IsDeleted == false)
            {
                return true;
            }

            if (friendship != null && friendship.IsDeleted == true)
            {
                var friendship2 = await this.context.Friends
                    .FirstOrDefaultAsync(f => f.UserId == userFriendId && f.UserFriendId == userId);

                friendship.IsDeleted = false;
                friendship.DeletedOn = null;
                friendship2.IsDeleted = false;
                friendship2.DeletedOn = null;
                await this.context.SaveChangesAsync();

                return true;
            }

            var newFriendship = new Friend
            {
                UserId = userId,
                UserFriendId = userFriendId
            };
            var newFriendship2 = new Friend
            {
                UserId = userFriendId,
                UserFriendId = userId
            };

            await this.context.Friends.AddRangeAsync(newFriendship, newFriendship2);
            await this.context.SaveChangesAsync();

            return true;
        } //Ready

        public async Task<SocialMediaDTO> CreateSocialMediaAsync(SocialMediaDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidModel);
            }

            var socialMedia = this.mapper.Map<SocialMedia>(model);

            await this.context.SocialMedias.AddAsync(socialMedia);
            await this.context.SaveChangesAsync();

            return model;
        }   //Ready

        public Task<bool> DeleteFriendRequestAsync(Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await this.context.Users
                           .Include(u => u.Town).ThenInclude(x=>x.Country)
                           .Include(u => u.FriendRequests)
                           .Include(u => u.SocialMedias)
                           .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id)
                     ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<UserDTO>(user);
        }    //Ready

        public async Task<bool> RemoveFriendAsync(Guid userId, Guid userFriendId)
        {
            var friendship = await this.context.Friends
                .FirstOrDefaultAsync(f => f.UserId == userId && f.UserFriendId == userFriendId)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var friendship2 = await this.context.Friends
                .FirstOrDefaultAsync(f => f.UserId == userFriendId && f.UserFriendId == userId)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            friendship.IsDeleted = true;
            friendship.DeletedOn = DateTime.UtcNow;
            friendship2.IsDeleted = true;
            friendship2.DeletedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return true;
            }   //Ready

        public Task<FriendRequestDTO> SendFriendRequestAsync(Guid receiverId)
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

        public async Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id)
        {
            var friendships = await this.context.Friends
                .Where(f => !f.IsDeleted && f.UserId == id)
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
        } //Ready

        public async Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid id)
        {
            var user = await this.context.Users
                .Include(u => u.FriendRequests).ThenInclude(u => u.Receiver)
                .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return user.FriendRequests.Select(this.mapper.Map<FriendRequestDTO>);
        }   // Ready

        public async Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid id)
        {
            var friendRequests = await this.context.FriendRequests
                .Where(f => !f.IsDeleted && f.ReceiverId == id)
                .Include(f => f.Sender)
                .Include(f => f.Receiver)
                .ToListAsync();

            if (!friendRequests.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return friendRequests.Select(this.mapper.Map<FriendRequestDTO>);
        }   // Ready
    }
}

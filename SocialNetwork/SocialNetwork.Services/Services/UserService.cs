using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
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

        public UserManager<User> UserManager { get; }

        public UserService(SocialNetworkDBContext context,
                           IMapper mapper
                          /* UserManager<User> userManager*/)
        {
            this.context = context;
            this.mapper = mapper;
            //UserManager = userManager;
        }

        public async Task<bool> AcceptFriendRequestAsync(Guid senderId, Guid receiverId)
        {
            var accepted = await this.AddFriendAsync(senderId, receiverId);

            if (accepted)
            {
                await this.DeleteFriendRequestAsync(senderId, receiverId);
                return true;
            }

            throw new ArgumentException(ExceptionMessages.SomethingWentWrong);
        }

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
        }

        public async Task<bool> DeleteFriendRequestAsync(Guid senderId, Guid receiverId)
        {
            var friendship = await this.context.FriendRequests
                                        .FirstOrDefaultAsync(f => f.SenderId == senderId && f.ReceiverId == receiverId)
                           ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            friendship.IsDeleted = true;
            friendship.DeletedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await this.context.Users.Where(u => !u.IsDeleted && u.Id == id)
                           .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                           .FirstOrDefaultAsync()
                     ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            user.Friends = user.Friends.Where(f => !f.IsDeleted).ToList();
            return user;
        }

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
        }

        public async Task<FriendRequestDTO> SendFriendRequestAsync(Guid senderId, Guid receiverId) //check if person already sent us fr
        {
            var oldFriendRequest = await this.context.FriendRequests
                .FirstOrDefaultAsync(f => f.SenderId == senderId && f.ReceiverId == receiverId);

            if (oldFriendRequest != null && oldFriendRequest.IsDeleted)
            {
                oldFriendRequest.IsDeleted = false;
                oldFriendRequest.DeletedOn = null;
                oldFriendRequest.CreatedOn = DateTime.UtcNow;
                await this.context.SaveChangesAsync();

                return this.mapper.Map<FriendRequestDTO>(oldFriendRequest);
            }

            var friendRequest = new FriendRequest
            {
                SenderId = senderId,
                ReceiverId = receiverId
            };

            await this.context.FriendRequests.AddAsync(friendRequest);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<FriendRequestDTO>(friendRequest);
        } // Ready

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await this.context.Users
                                  .Where(u => !u.IsDeleted)
                                  .ProjectTo<UserDTO>(this.mapper.ConfigurationProvider)
                                  .ToListAsync();

            if (!users.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitiesNotFound);
            }

            return users; //users.Select(this.mapper.Map<UserDTO>);
        }

        public async Task<IEnumerable<UserDTO>> GetFriendsAsync(Guid id)
        {
            var friends = await this.context.Friends
                 .Where(f => !f.IsDeleted && f.UserId == id)
                 .Select(f => f.UserFriend)
                 .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                 .ToListAsync();

            if (!friends.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitiesNotFound);
            }

            return friends;
        }

        public async Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsSentAsync(Guid id)
        {
            var user = await this.context.Users
                      .Where(u => !u.IsDeleted && u.Id == id)
                      .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync()
                    ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return user.FriendRequests;
        }

        public async Task<IEnumerable<FriendRequestDTO>> GetAllFriendRequestsReceivedAsync(Guid id)
        {
            var friendRequests = await this.context.FriendRequests
                                .Where(f => !f.IsDeleted && f.ReceiverId == id && !f.Sender.IsDeleted)
                                .ProjectTo<FriendRequestDTO>(mapper.ConfigurationProvider)
                                .OrderByDescending(f => f.CreatedOn)
                                .ToListAsync()
                               ?? throw new ArgumentException(ExceptionMessages.EntitiesNotFound);

            return friendRequests;
        }

        public async Task<IEnumerable<UserDTO>> GetByUserNameAsync(string searchCriteria = "", string sortOrder = "nameAsc")
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCriteria);
            }

            var result = await this.context.Users
                            .Where(u => !u.IsDeleted && (u.DisplayName.Contains(searchCriteria) || u.UserName.Contains(searchCriteria)))
                            .ProjectTo<UserDTO>(this.mapper.ConfigurationProvider)
                            .ToListAsync()
                       ?? throw new ArgumentException(ExceptionMessages.EntitiesNotFound);

            if (sortOrder == "nameDesc")
            {
                return result.OrderByDescending(p => p.DisplayName);
            }
            else if (sortOrder == "mostRecent")
            {
                return result.OrderByDescending(p => p.CreatedOn);
            }

            return result.OrderBy(p => p.DisplayName);
        }

        public async Task<bool> AreFriendsAsync(Guid senderId, Guid receiverId)
        {
            return await this.context.Friends
                .AnyAsync(f => !f.IsDeleted &&
                               ((f.UserId == senderId && f.UserFriendId == receiverId) ||
                               (f.UserId == receiverId && f.UserFriendId == senderId)));
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            try
            {
                var user = await this.context.Users.FirstAsync(u => u.Id == userId);

                user.IsDeleted = true;
                user.DeletedOn = DateTime.UtcNow;

                await this.context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsLegitAsync(string userEmail)
        {
            var user = await this.context.Users
                                 .FirstOrDefaultAsync(u => u.Email == userEmail && !u.IsDeleted);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<(int, int, int, int)> GetStatistics()
        {
            (int userCount, int connectionsCount, int postsCount, int commentsCount) statistics;

            statistics.userCount = await this.context.Users.CountAsync(u => !u.IsDeleted);
            statistics.connectionsCount = await this.context.Friends.CountAsync(u => !u.IsDeleted) / 2;
            statistics.postsCount = await this.context.Posts.CountAsync(u => !u.IsDeleted);
            statistics.commentsCount = await this.context.Comments.CountAsync(u => !u.IsDeleted);

            return statistics;
        }

        private async Task<bool> AddFriendAsync(Guid userId, Guid userFriendId)
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
        }
    }
}

﻿using AutoMapper;
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
    public class PostService : IPostService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public PostService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PostDTO> CreateAsync(PostDTO post)
        {
            var user = await this.context.Users
                           .FirstOrDefaultAsync(x => x.Id == post.UserId);

            var newPost = this.mapper.Map<Post>(post);
            newPost.User = user;
            newPost.Video = null;
            newPost.Photo = null;

            await this.context.Posts.AddAsync(newPost);
            await this.context.SaveChangesAsync();

            return post;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var post = await this.context.Posts
                               .FirstOrDefaultAsync(p => p.Id == id);

                post.IsDeleted = true;
                post.DeletedOn = DateTime.UtcNow;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PostDTO> GetByIdAsync(int id)
        {
            var post = await this.context.Posts
                            .Include(p => p.User)
                            .Include(p => p.Photo)
                            .Include(p => p.Video)
                            .Include(p => p.Likes).ThenInclude(l => l.User)
                            .Include(p => p.Comments).ThenInclude(c => c.User)
                            .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id)
                    ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId)
        {
            throw new NotImplementedException();
            var user = this.context.Users
                           .Include(u => u.Friends)
                           .Include(u => u.FriendsOf)
                           .FirstOrDefault(u => u.Id == userId);

            var friendsPosts = new List<Post>();

            foreach (var friend in user.Friends)
            {
                var currFriendsPosts = this.context.Posts
                           .Where(p => !p.IsDeleted && (p.UserId == friend.UserId) || (p.UserId == friend.UserFriendId))
                           .Include(p => p.User)
                           .Include(p => p.Photo)
                           .Include(p => p.Video)
                           .Include(p => p.Likes)
                               .ThenInclude(l => l.User)
                           .Include(p => p.Comments)
                               .ThenInclude(c => c.User);

                friendsPosts.AddRange(currFriendsPosts);
            }

            if (!friendsPosts.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            var asd = friendsPosts.Select(this.mapper.Map<PostDTO>);

            return default;
        }

        public async Task<IEnumerable<PostDTO>> GetUserPostsAsync(Guid userId)
        {
            var posts = await this.context.Posts
                          .Where(p => !p.IsDeleted && p.UserId == userId)
                          .Include(p => p.User)
                          .Include(p => p.Photo)
                          .Include(p => p.Video)
                          .Include(p => p.Likes).ThenInclude(l => l.User)
                          .Include(p => p.Comments).ThenInclude(c => c.User)
                          .ToListAsync();

            if (!posts.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return posts.Select(this.mapper.Map<PostDTO>);
        }
    }
}
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
    public class PostService : IPostService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public PostService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PostDTO> CreateAsync(PostDTO postDTO, PhotoDTO photoDTO = null, VideoDTO videoDTO = null)
        {
            if (postDTO == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidModel);
            }

            // Create the post
            var user = await this.context.Users
               .FirstOrDefaultAsync(u => u.Id == postDTO.UserId)
               ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var post = this.mapper.Map<Post>(postDTO);

            post.UserId = postDTO.UserId;
            post.User = user;

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();

            // Create the media
            AddMediaToPost(photoDTO, videoDTO, post);

            // Save the changes
            await this.context.SaveChangesAsync();

            return this.mapper.Map<PostDTO>(post); // TODO: QUestion
        }

        private void AddMediaToPost(PhotoDTO photoDTO, VideoDTO videoDTO, Post post)
        {
            if (photoDTO != null)
            {
                var photo = this.mapper.Map<Photo>(photoDTO);
                photo.PostId = post.Id;

                post.Photo = photo;
                post.Video = null;
            }
            else if (videoDTO != null)
            {
                var video = this.mapper.Map<Video>(videoDTO);
                video.PostId = post.Id;

                post.Video = video;
                post.Photo = null;
            }
            else
            {
                post.Photo = null;
                post.Video = null;
            }
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

        public async Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId)   //TODO: Add algorythm
        {
            var friendships = await this.context.Friends
                .Where(f => f.UserId == userId)
                .ToListAsync();

            var friendsPosts = new List<Post>();

            foreach (var fs in friendships)
            {
                var currFriendsPosts = await this.context.Posts
                    .Where(p => !p.IsDeleted && p.UserId == fs.UserFriendId)
                    .Include(p => p.User)
                    .Include(p => p.Photo)
                    .Include(p => p.Video)
                    .Include(p => p.Likes).ThenInclude(l => l.User)
                    .Include(p => p.Comments).ThenInclude(c => c.User)
                    .ToListAsync();

                friendsPosts.AddRange(currFriendsPosts);
            }

            if (!friendsPosts.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return friendsPosts.Select(this.mapper.Map<PostDTO>);
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

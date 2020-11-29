using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Constants;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class LikeService : ILikeService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public LikeService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> LikeAsync(PostDTO postDTO)
        {
            var like = await this.context.Likes
               .FirstOrDefaultAsync(l => l.UserId == postDTO.UserId && l.PostId == postDTO.Id);

            if (like == null)
            {
                var addLike = new Like
                {
                    UserId = postDTO.UserId,
                    PostId = postDTO.Id,
                    CreatedOn = DateTime.UtcNow,
                };

                postDTO.Likes.Add(this.mapper.Map<LikeDTO>(like));
                await this.context.Likes.AddAsync(addLike);
                await this.context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var like = await this.context.Likes
                     .Include(p => p.User)
                     .FirstOrDefaultAsync(l => !l.IsDeleted && l.Id == id);

                like.IsDeleted = true;
                like.DeletedOn = DateTime.UtcNow;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } //remove

        public async Task<LikeDTO> GetByIdAsync(int id)
        {
            var like = await this.context.Likes
                                 .Include(p => p.User)
                                 .FirstOrDefaultAsync(l => !l.IsDeleted && l.Id == id)
                                 ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<LikeDTO>(like);
        } //remove

        public async Task<bool> DislikeAsync(PostDTO postDTO)
        {
            var like = await this.context.Likes
                .FirstOrDefaultAsync(l => l.UserId == postDTO.UserId && l.PostId == postDTO.Id);

            if (like != null)
            {
                postDTO.Likes.Remove(this.mapper.Map<LikeDTO>(like));
                this.context.Likes.Remove(like);
                await this.context.SaveChangesAsync();
                return false;
            }

            return true;
        }
    }
}

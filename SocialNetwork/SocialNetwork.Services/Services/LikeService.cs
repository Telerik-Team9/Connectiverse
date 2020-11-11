using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Constants;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
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

        public async Task<LikeDTO> CreateAsync(LikeDTO likeDTO)
        {
            if (likeDTO == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidModel);
            }

            var user = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == likeDTO.UserId)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var post = await this.context.Posts
                .FirstOrDefaultAsync(p => p.Id == likeDTO.PostId)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var newLike = this.mapper.Map<Like>(likeDTO);
            newLike.User = user;
            newLike.Post = post;

            await this.context.Likes.AddAsync(newLike);
            await this.context.SaveChangesAsync();

            return likeDTO;
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
        }

        public async Task<LikeDTO> GetByIdAsync(int id)
        {
            var like = await this.context.Likes
                                 .Include(p => p.User)
                                 .FirstOrDefaultAsync(l => !l.IsDeleted && l.Id == id)
                                 ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<LikeDTO>(like);
        }
    }
}

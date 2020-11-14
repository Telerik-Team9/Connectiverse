using AutoMapper;
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
                //.Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == likeDTO.PostId)
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

           // var present = post.Likes.FirstOrDefault(like => like.UserId == user.Id);   // if a like is present - it will remove it
           //                                                                            // if a like is present - it will remove it
           // if (present != null)                                                       // if a like is present - it will remove it
           // {                                                                          // if a like is present - it will remove it
           //     var dislike = await this.context.Likes                                 // if a like is present - it will remove it
           //         .FirstOrDefaultAsync(like => like.Id == present.Id);               // if a like is present - it will remove it
           //     dislike.IsDeleted = true;
           //     dislike.DeletedOn = DateTime.UtcNow;                                                                      // if a like is present - it will remove it
           //   //this.context.Likes.Remove(dislike);                                    // if a like is present - it will remove it
           //     await this.context.SaveChangesAsync();                                 // if a like is present - it will remove it
           //                                                                            // if a like is present - it will remove it
           //     return likeDTO;                                                        // if a like is present - it will remove it
           // }

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

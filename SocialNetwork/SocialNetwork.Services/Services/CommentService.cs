using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class CommentService : ICommentService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public CommentService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CommentDTO> CreateAsync(CommentDTO commentDTO)
        {
            if (commentDTO.PostId == 0 || commentDTO == null)
            {
                throw new ArgumentNullException(ExceptionMessages.EntityNotFound);
            }

            var user = await this.context.Users
                          .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == commentDTO.UserId)
                      ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var post = await this.context.Posts
                        .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == commentDTO.PostId)
                    ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            // Create the comment and add it to the DB
            var comment = this.mapper.Map<Comment>(commentDTO);
            comment.Post = post;
            comment.User = user;

            await this.context.Comments.AddAsync(comment);
            await this.context.SaveChangesAsync();

            return commentDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await this.context.Comments
                                 .FirstOrDefaultAsync(c => c.Id == id);

                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;

                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CommentDTO>> GetAllAsync()
        {
            return await this.context.Comments
                .Where(c => !c.IsDeleted)
                .ProjectTo<CommentDTO>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

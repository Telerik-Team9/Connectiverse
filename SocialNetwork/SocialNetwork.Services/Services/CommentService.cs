using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<CommentDTO> GetAll()
        {
            var allComments = this.context.Comments
                                  .Where(c => !c.IsDeleted)
                                  .Include(c => c.Post)
                                  .Include(c => c.User);

            var result = allComments.Select(this.mapper.Map<CommentDTO>);

            return result;
        }

        public CommentDTO GetById(int id)
        {
            //TODO: SEED USER DISPLAYNAMES
            var comment = this.context.Comments
                                  .Include(c => c.Post)
                                  .Include(c => c.User)
                                  .FirstOrDefault(x => x.Id == id);

            var dto = this.mapper.Map<CommentDTO>(comment);
            return dto;
        }
    }
}

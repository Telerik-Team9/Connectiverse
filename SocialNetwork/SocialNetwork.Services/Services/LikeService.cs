using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Services.Services
{
    public class LikeService : ILIkeService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public LikeService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LikeDTO Create(LikeDTO comment)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LikeDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeDTO> GetPostLikes(int postId)
        {
            var postLikes = this.context.Likes
                                .Where(l => !l.IsDeleted && l.PostId == postId)
                                .Include(l => l.Post)
                                .Include(l => l.User);

            var DTOs = postLikes.Select(this.mapper.Map<LikeDTO>);

            return DTOs;
        }
    }
}

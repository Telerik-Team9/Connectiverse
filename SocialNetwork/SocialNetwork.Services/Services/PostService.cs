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
    public class PostService : IPostService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public PostService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<PostDTO> GetAll()
        {
            var allPosts = this.context.Posts
                               .Where(p => !p.IsDeleted)
                               .Include(p => p.User)
                               .Include(p => p.Photo)
                               .Include(p => p.Video)
                               .Include(p => p.Likes)
                               .Include(p => p.Comments);

            var result = allPosts.Select(this.mapper.Map<PostDTO>);

            return result;
        }

        public PostDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

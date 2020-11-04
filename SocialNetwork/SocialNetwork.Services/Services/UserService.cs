using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Services.Services
{
    public class UserService : IUserService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;
        //TODO: Inject USerManager
        public UserService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IEnumerable<UserDTO> GetAll()
        {
            var users = this.context.Users
                            .Include(u => u.Town).ThenInclude(t => t.Country)
                            .Include(u => u.Friends)
                            .Include(u => u.FriendRequests)
                            .Include(u => u.Posts)
                            .Include(u => u.SocialMedias)
                            .Include(u => u.Likes)
                            .Include(u => u.Comments);

            var result = users.Select(this.mapper.Map<UserDTO>);
            return result;
        }
    }
}

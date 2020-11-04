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
    // DELETE!
    public class FriendService : IFriendService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public FriendService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public FriendDTO GetById(int id)
        {
            var friends = this.context.Friends
                .Include(f => f.User)
                .Include(f => f.UserFriend);

            var friendsDTOs = friends.Select(this.mapper.Map<FriendDTO>);

            return friendsDTOs.FirstOrDefault();
        }
    }
}

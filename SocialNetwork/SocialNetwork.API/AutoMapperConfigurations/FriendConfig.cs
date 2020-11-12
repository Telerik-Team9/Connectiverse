using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.API.AutoMapperConfigurations
{
    public class FriendConfig : Profile
    {
        public FriendConfig()
        {
            this.CreateMap<Friend, FriendDTO>()
                .ReverseMap();
        }
    }
}

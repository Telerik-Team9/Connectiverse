using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.API.AutoMapperConfigurations
{
    public class FriendRequestConfig : Profile
    {
        public FriendRequestConfig()
        {
            this.CreateMap<FriendRequest, FriendRequestDTO>()
                   .ReverseMap();
        }
    }
}

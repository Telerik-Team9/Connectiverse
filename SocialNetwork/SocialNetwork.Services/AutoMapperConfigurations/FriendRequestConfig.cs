using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class FriendRequestConfig : Profile
    {
        public FriendRequestConfig()
        {
            this.CreateMap<FriendRequest, FriendRequestDTO>();
        }
    }
}

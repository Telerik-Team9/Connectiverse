using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class FriendRequestVMConfig : Profile
    {
        public FriendRequestVMConfig()
        {
            this.CreateMap<FriendRequest, FriendRequestDTO>()
                .ReverseMap();
            this.CreateMap<FriendRequestDTO, FriendRequestViewModel>()
                .ReverseMap();
        }
    }
}

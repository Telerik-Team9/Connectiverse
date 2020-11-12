using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class FriendVMConfig : Profile
    {
        public FriendVMConfig()
        {
            this.CreateMap<Friend, FriendDTO>()
                .ReverseMap();
            this.CreateMap<FriendDTO, FriendViewModel>()
                .ReverseMap();
        }
    }
}

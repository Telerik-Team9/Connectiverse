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
                .ForMember(dest => dest.IsDeleted,
                                   opt => opt.MapFrom(src => src.UserFriend.IsDeleted))
                .ReverseMap();
            this.CreateMap<FriendDTO, FriendViewModel>()
                .ReverseMap();
        }
    }
}

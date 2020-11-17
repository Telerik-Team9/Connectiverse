using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class UserProfileVMConfig : Profile
    {
        public UserProfileVMConfig()
        {
            this.CreateMap<User, UserDTO>()
                .ReverseMap();
            this.CreateMap<UserDTO, UserSearchViewModel>()
                .ReverseMap();
        }
    }
}

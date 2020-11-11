using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class UserVMConfig : Profile
    {
        public UserVMConfig()
        {
            this.CreateMap<User, UserDTO>()
                .ReverseMap();
            this.CreateMap<UserDTO, UserViewModel>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class UserModelConfig : Profile
    {
        public UserModelConfig()
        {
            this.CreateMap<User, UserDTO>()
                .ReverseMap();
            this.CreateMap<UserDTO, UserProfileInfoModel>()
                .ReverseMap();
        }
    }
}

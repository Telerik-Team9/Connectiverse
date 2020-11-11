using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class UserModelConfig : Profile
    {
        public UserModelConfig()
        {
            this.CreateMap<UserDTO, UserProfileInfoModel>();
        }
    }
}

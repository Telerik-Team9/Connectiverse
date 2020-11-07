using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

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

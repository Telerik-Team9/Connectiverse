using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class UserConfig : Profile
    {
        public UserConfig()
        {
            this.CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

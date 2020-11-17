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
            this.CreateMap<User, UserDTO>()/*.ForMember(opt => opt.Friends, dest => dest.MapFrom(u => u.Friends.Where(f => !f.IsDeleted)))*/
                .ReverseMap();
            this.CreateMap<UserDTO, UserViewModel>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;
using System.Linq;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class UserVMConfig : Profile
    {
        public UserVMConfig()
        {
            this.CreateMap<User, UserDTO>()
                .ForMember(opt => opt.Posts,
                           dest => dest.MapFrom(x => x.Posts.Where(p => !p.IsDeleted)))
                .ForMember(opt => opt.Friends,
                           dest => dest.MapFrom(u => u.Friends.Where(f => !f.IsDeleted))) // Bug fixed
                .ReverseMap();
            this.CreateMap<UserDTO, UserViewModel>()
                .ReverseMap();
        }
    }
}

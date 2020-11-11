using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class PostVMConfig : Profile
    {
        public PostVMConfig()
        {
            this.CreateMap<Post, PostDTO>()
                .ReverseMap();
            this.CreateMap<PostDTO, PostViewModel>()
                .ReverseMap();
        }
    }
}

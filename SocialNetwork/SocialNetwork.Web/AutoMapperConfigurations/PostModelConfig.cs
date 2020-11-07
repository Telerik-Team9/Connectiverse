using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class PostModelConfig : Profile
    {
        public PostModelConfig()
        {
            this.CreateMap<PostDTO, PostModel>()
                .ReverseMap();
        }
    }
}

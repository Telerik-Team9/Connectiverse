using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Services.DTOs;

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

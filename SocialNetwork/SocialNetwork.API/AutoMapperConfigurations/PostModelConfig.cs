using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class PostModelConfig : Profile
    {
        public PostModelConfig()
        {
            this.CreateMap<Post, PostDTO>()
                .ReverseMap();
            this.CreateMap<PostDTO, PostModel>()
                .ReverseMap();
            this.CreateMap<PostInputModel, PostDTO>();
        }
    }
}

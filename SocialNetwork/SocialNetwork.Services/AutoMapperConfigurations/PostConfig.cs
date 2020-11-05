using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class PostConfig : Profile
    {
        public PostConfig()
        {
            this.CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}

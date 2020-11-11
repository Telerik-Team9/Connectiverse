using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class LikeConfig : Profile
    {
        public LikeConfig()
        {
            this.CreateMap<Like, LikeDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class LikeModelConfig : Profile
    {
        public LikeModelConfig()
        {
            this.CreateMap<Like, LikeDTO>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using SocialNetwork.API.Models;
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
            this.CreateMap<LikeDTO, LikeModel>()
                .ReverseMap();
        }
    }
}
